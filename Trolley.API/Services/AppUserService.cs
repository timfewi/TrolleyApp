using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public class AppUserService : BaseService
    {
        public AppUserService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

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
    }
}
