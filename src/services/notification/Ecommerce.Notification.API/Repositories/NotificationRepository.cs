using AutoMapper;
using Ecommerce.Base.Client.Models;
using Ecommerce.EntityFrameworkCore.Repositories;
using Ecommerce.Notification.API.Models;

namespace Ecommerce.Notification.API.Repositories
{
    public class NotificationRepository : EfCoreRepository<Entities.Notification, NotificationDbContext>, INotificationRepository
    {
        #region Fields

        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public NotificationRepository(NotificationDbContext context, IMapper mapper) : base(context) 
        {
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse> Create(NotificationModel model)
        {
            try
            {
                var entity = _mapper.Map<Entities.Notification>(model);
                entity.SentAt = DateTime.UtcNow;

                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

                return new EcommerceClientResponse();
            }
            catch (Exception ex)
            {
                return new EcommerceClientResponse(ex);
            }
        }

        #endregion
    }
}