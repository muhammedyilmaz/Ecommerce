using AutoMapper;
using Ecommerce.Notification.API.Models;

namespace Ecommerce.Notification.API.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Notification, NotificationModel>();
            CreateMap<NotificationModel, Entities.Notification>();
        }
    }
}
