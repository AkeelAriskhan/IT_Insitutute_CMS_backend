using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.IRepositories;
using Microsoft.Data.Sqlite;

namespace IT_Insitutute_CMS.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddStudent(Student student)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Students(Nic,FullName,Email,PhoneNumber,Password,RegistrationFee,ImagePath) VALUES(@Nic,@FullName,@Email,@PhoneNumber,@Password,@RegistrationFee,@imagePath)";
                command.Parameters.AddWithValue("@Nic", student.Nic);
                command.Parameters.AddWithValue("@FullName", student.FullName);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                command.Parameters.AddWithValue("@Password", student.Password);
                command.Parameters.AddWithValue("@RegistrationFee", student.RegistrationFee);
                command.Parameters.AddWithValue("@imagePath", student.ImagePath == null ? "" : student.ImagePath);
                command.ExecuteNonQuery();
            }

        }
    }
}
