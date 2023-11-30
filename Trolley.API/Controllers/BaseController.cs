using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Data;

namespace Trolley.API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly TrolleyDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        protected readonly IMapper _mapper;
        protected readonly ILogger<BaseController> _logger;




        public BaseController(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService(typeof(TrolleyDbContext)) as TrolleyDbContext;
            _mapper = _serviceProvider.GetRequiredService(typeof(IMapper)) as IMapper;
            _logger = _serviceProvider.GetRequiredService(typeof(ILogger<BaseController>)) as ILogger<BaseController>;
        }
    }
}
