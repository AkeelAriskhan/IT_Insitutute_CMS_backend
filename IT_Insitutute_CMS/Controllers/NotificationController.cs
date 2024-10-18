using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IT_Insitutute_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationsRepository;

        public NotificationController(INotificationRepository notificationsRepository)
        {
            _notificationsRepository = notificationsRepository;
        }

    }
}
