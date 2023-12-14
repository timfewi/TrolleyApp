using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trolley.API.Dtos;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public class AdminService : BaseService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminService(IServiceProvider serviceProvider, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager) : base(serviceProvider)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // Get all Users
        public async Task<List<AppUser>> GetUsersAsync()
        {
            try
            {
                return await _userManager.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find users", ex);
            }
        }

        // Get all User roles
        public async Task<List<string>> GetUserRolesAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return null;
                }

                return await _userManager.GetRolesAsync(user) as List<string>;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find roles for user with id {userId}", ex);
            }
        }

        // Get User with roles
        public async Task<List<UserWithRolesDto>> GetAllUsersWithRolesAsync()
        {
            try
            {
                var usersWithRoles = new List<UserWithRolesDto>();

                var users = await _userManager.Users.ToListAsync();
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    usersWithRoles.Add(new UserWithRolesDto
                    {
                        User = user,
                        Roles = roles.ToList()
                    });
                }

                return usersWithRoles;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find users with roles", ex);
            }
        }

        // Update User roles
        public async Task<bool> UpdateUserRolesAsync(string userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return false;
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, userRoles);
                if (!result.Succeeded)
                {
                    _logger.LogError($"Couldn't remove roles from user {user.UserName}");
                    return false;
                }

                result = await _userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded)
                {
                    _logger.LogError($"Couldn't add role to user {user.UserName}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't update roles for user with id {userId}", ex);
                return false;
            }
        }

        // Add a role to User
        public async Task<bool> AddRoleToUserAsync(string userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return false;
                }

                var role = await _roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    _logger.LogError($"Couldn't find role with name {roleName}");
                    return false;
                }

                var result = await _userManager.AddToRoleAsync(user, role.Name);
                if (!result.Succeeded)
                {
                    _logger.LogError($"Couldn't add role {role.Name} to user {user.UserName}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't add role {roleName} to user with id {userId}", ex);
            }
        }

        // Remove a role from User
        public async Task<bool> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return false;
                }

                var role = await _roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    _logger.LogError($"Couldn't find role with name {roleName}");
                    return false;
                }

                var result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                if (!result.Succeeded)
                {
                    _logger.LogError($"Couldn't remove role {role.Name} from user {user.UserName}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't remove role {roleName} from user with id {userId}", ex);
            }
        }

        // Edit User
        public async Task<bool> EditUserAsync(string userId, string newEmail, string newUserName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return false;
                }

                user.Email = newEmail;
                user.UserName = newUserName;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    _logger.LogError($"Couldn't update user {user.UserName}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't update user with id {userId}", ex);
            }
        }

        // Delete User
        public async Task<bool> DeleteUserAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return false;
                }

                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    _logger.LogError($"Couldn't delete user {user.UserName}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete user with id {userId}", ex);
            }
        }


    }
}
