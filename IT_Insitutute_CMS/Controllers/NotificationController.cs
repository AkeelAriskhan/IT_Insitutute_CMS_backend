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

        [HttpGet("Get-All-Notifications")]

        public IActionResult GetAllCourseNotifications()
        {
            var notificationList = _notificationsRepository.GetAllNotifications();
            return Ok(notificationList);
        }

        [HttpPost("Add-Notification")]

        public IActionResult AddCourseNotification(NotificationRequest notification)
        {
            _notificationsRepository.AddNotification(notification);
            return Ok("Notification Added Successfully..");
        }

        [HttpDelete("Delete-Notification/{Id}")]

        public IActionResult DeleteCourseNotification(int Id)
        {
            _notificationsRepository.DeleteNotification(Id);
            return Ok("Deleted Successfully...");
        }
    }
}
