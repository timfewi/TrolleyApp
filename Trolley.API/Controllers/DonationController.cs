using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Trolley.API.Dtos;
using Trolley.API.Entities;

namespace Trolley.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public DonationController(IServiceProvider serviceProvider, UserManager<AppUser> userManager, IConfiguration configuration)
            : base(serviceProvider)
        {
            _userManager = userManager;
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreateDonation")]
        [Authorize]
        public async Task<IActionResult> CreateDonation([FromBody] CreateDonationDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Benutzer ist nicht authentifiziert.");
            }

            var frontendBaseUrl = _configuration["FrontendBaseUrl"];
            try
            {
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmount = dto.Amount,
                                Currency = "EUR",
                                ProductData = new SessionLineItemPriceDataProductDataOptions { Name = "Donation" },
                            },
                            Quantity = 1,
                        },
                    },
                    Mode = "payment",
                    SuccessUrl = $"{frontendBaseUrl}donation/success?session_id={{CHECKOUT_SESSION_ID}}",
                    CancelUrl = $"{frontendBaseUrl}donation/cancel",

                };

                var service = new SessionService();
                var session = await service.CreateAsync(options);

                return Ok(new CreateDonationResponseDto { SessionId = session.Id, PubKey = _configuration["Stripe:PubKey"], Amount = dto.Amount });
            }
            catch (StripeException ex)
            {
                _logger.LogError($"Fehler beim Erstellen der Stripe-Sitzung: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Fehler beim Verbinden mit Stripe");
            }
        }

        [HttpGet("success")]
        public async Task<IActionResult> Success(string sessionId)
        {
            var sessionService = new SessionService();
            var session = await sessionService.GetAsync(sessionId);

            //TODO: use invoice service to get invoice
            var invoiceService = new InvoiceService();
            var invoiceOptions = new InvoiceListOptions
            {
                Customer = session.CustomerId,
                CollectionMethod = "charge_automatically",

            };

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(session.PaymentIntentId);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"Couldn't find user with id {userId}");
                return BadRequest($"Couldn't find user with id {userId}");
            }

            var donation = new Donation
            {
                Amount = paymentIntent.Amount,
                AppUserId = userId,
                PaymentIntentId = paymentIntent.Id,
                PaymentStatus = paymentIntent.Status,
                PaymentMethod = paymentIntent.PaymentMethodId,
                ReceiptEmail = paymentIntent.ReceiptEmail,
                CustomerId = session.CustomerId,
                PaymentDate = paymentIntent.Created,
            };

            var frontendBaseUrl = _configuration["FrontendBaseUrl"];
            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();


            var addToRoleResult = await _userManager.AddToRoleAsync(user, "PremiumUser");
            if (!addToRoleResult.Succeeded)
            {
                _logger.LogError($"Couldn't add role PremiumUser to user with id {userId}");
                return BadRequest($"Couldn't add role PremiumUser to user with id {userId}");
            }

            return Redirect($"{frontendBaseUrl}donation/success?session_id={sessionId}");
        }
    }
}
