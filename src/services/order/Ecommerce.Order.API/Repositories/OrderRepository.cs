using AutoMapper;
using Ecommerce.Base.Client.Models;
using Ecommerce.EntityFrameworkCore.Repositories;
using Ecommerce.Order.API.Models;

namespace Ecommerce.Order.API.Repositories
{
    public class OrderRepository : EfCoreRepository<Entities.Order, OrderDbContext>, IOrderRepository
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly ILogger<OrderRepository> _logger;

        #endregion

        #region Ctor

        public OrderRepository(OrderDbContext context, 
            IMapper mapper,
            ILogger<OrderRepository> logger) : base(context) 
        {
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse<OrderModel>> CreateOrder(OrderCreatedRequest request)
        {
            try
            {
                //model to entity map
                var entity = _mapper.Map<Entities.Order>(request.Order);

                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Sipariş oluştu. Sipariş no: {entity.Id}");

                //entity to model map
                var model = _mapper.Map<OrderModel>(entity);

                return new EcommerceClientResponse<OrderModel>(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Sipariş oluşurken hata oluştu. Sipariş no: {ex.Message}");
                return new EcommerceClientResponse<OrderModel>(ex);
            }
        }

        #endregion
    }
}