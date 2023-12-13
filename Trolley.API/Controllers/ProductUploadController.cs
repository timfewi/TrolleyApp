using Microsoft.AspNetCore.Mvc;

namespace Trolley.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductUploadController : BaseController
    {
        public ProductUploadController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }


    }
}
