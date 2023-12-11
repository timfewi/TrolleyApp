using System.Security.Claims;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
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
        private static string clientURL = string.Empty;
        private readonly UserManager<AppUser> _userManager;

        public DonationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [Route("CreateDonation")]
        public async Task<IActionResult> CreateDonation([FromBody] CreateDonationDto dto, [FromServices] IServiceProvider serviceProvider)
        {
            var referer = Request.Headers.Referer;
            clientURL = referer[0];

            var server = serviceProvider.GetRequiredService<IServer>();
            var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();
            string? thisApiUrl = null;

            if (serverAddressesFeature != null)
            {
                thisApiUrl = serverAddressesFeature.Addresses.FirstOrDefault();
            }

            if (thisApiUrl is not null)
            {
                var sessionId = await Checkout(dto, thisApiUrl);
                var pubKey = _configuration["Stripe:PubKey"];

                var createDonationResponse = new CreateDonationResponseDto
                {
                    SessionId = sessionId,
                    PubKey = pubKey,
                };

                return Ok(createDonationResponse);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server address not found.");
            }
        }

        [NonAction]
        private async Task<string> Checkout(CreateDonationDto dto, string thisApiUrl)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"Couldn't find user with id {userId}");
                return "Couldn't find user.";
            }

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = dto.Amount,
                            Currency = "EUR",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Donation",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = $"{clientURL}/donation/success?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{clientURL}/donation/cancel",
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            var customerId = session.CustomerId;

            Console.WriteLine("Customer ID: " + customerId);


            return session.Id;
        }

        [HttpGet("success")]
        public async Task<IActionResult> Success(string sessionId)
        {
            var sessionService = new SessionService();
            var session = await sessionService.GetAsync(sessionId);

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

            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();

            return Redirect($"{clientURL}/donation/success?session_id={sessionId}");
        }
    }
}
