using Microsoft.AspNetCore.Mvc;
using Trolley.API.Data;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : BaseController
    {
        public ShoppingListController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
