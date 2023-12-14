
using Trolley.API.Entities;

namespace Trolley.API.Dtos
{
    public class UserWithRolesDto
    {
        public AppUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}
