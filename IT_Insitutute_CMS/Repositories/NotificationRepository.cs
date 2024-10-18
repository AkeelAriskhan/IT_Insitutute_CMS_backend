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
        public void AddNotification(NotificationRequest notification)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO Notifications(Nic,Type,SourceId,Date,IsDeleted) Values (@nic,@type,@sourceId,@date,@isDeleted)";
                    command.Parameters.AddWithValue("@nic", notification.Nic);
                    command.Parameters.AddWithValue("@type", notification.Type);
                    command.Parameters.AddWithValue("@sourceId", notification.SourceId);
                    command.Parameters.AddWithValue("@date", notification.Date);
                    command.Parameters.AddWithValue("@isDeleted", false);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}
