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
        public ICollection<NotificationResponse> GetAllNotifications()
        {
            try
            {
                var notificationList = new List<NotificationResponse>();
                using (var connection = new SqliteConnection(_ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM Notifications";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var notification = new NotificationResponse()
                            {
                                Id = reader.GetInt32(0),
                                Nic = reader.GetString(1),
                                Type = reader.GetString(2),
                                SourceId = reader.GetString(3),
                                Date = reader.GetDateTime(4),
                                IsDeleted = reader.GetBoolean(5)
                            };
                            notificationList.Add(notification);
                        }
                    }
                }
                return notificationList;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}
