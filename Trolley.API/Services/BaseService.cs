using AutoMapper;
using Trolley.API.Data;

namespace Trolley.API.Services
{
    public class BaseService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly TrolleyDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        protected readonly IConfiguration _configuration;



        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = serviceProvider.GetRequiredService(typeof(TrolleyDbContext)) as TrolleyDbContext;
            _mapper = serviceProvider.GetRequiredService(typeof(IMapper)) as IMapper;
            _logger = serviceProvider.GetRequiredService(typeof(ILogger<BaseService>)) as ILogger<BaseService>;
            _configuration = serviceProvider.GetRequiredService(typeof(IConfiguration)) as IConfiguration;

        }
    }


}
