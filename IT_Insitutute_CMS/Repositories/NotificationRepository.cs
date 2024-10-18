using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Request;
using IT_Insitutute_CMS.Models.Responce;
using Microsoft.Data.Sqlite;

namespace IT_Insitutute_CMS.Repositories
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly string _ConnectionString;

        public NotificationRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }

    }
}
