using IT_Insitutute_CMS.Models.Request;
using IT_Insitutute_CMS.Models.Responce;

namespace IT_Insitutute_CMS.IRepositories
{
    public interface INotificationRepository
    {
        ICollection<NotificationResponse> GetAllNotifications();
        void AddNotification(NotificationRequest notification);
        void DeleteNotification(int id);
    }
}
