using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public class AppUserService : BaseService
    {
        private readonly UserManager<AppUser> _userManager;
        public AppUserService(IServiceProvider serviceProvider, UserManager<AppUser> userManager) : base(serviceProvider)
        {
            _userManager = userManager;

        }
        //Get all users
        public async Task<List<AppUser>> GetUsersAsync()
        {
            try
            {
                var users = await _context.Users
                    .Include(u => u.UserShoppingLists)
                    .ThenInclude(usl => usl.ShoppingList)
                    .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find users", ex);
            }
        }

        //Get user by id
        public async Task<AppUser> GetUserByIdAsync(string userId)
        {

            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find user with id: {userId}", ex);
            }
        }


    }
}
