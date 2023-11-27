using AutoMapper;
using Trolley.Domain.Data;

namespace Trolley.API.Services
{
    public class BaseService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly TrolleyDbContext _context;
        protected readonly IMapper _mapper;

        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = serviceProvider.GetRequiredService(typeof(TrolleyDbContext)) as TrolleyDbContext;
            _mapper = serviceProvider.GetRequiredService(typeof(IMapper)) as IMapper;

            // envtl bug 
        }
    }


}
