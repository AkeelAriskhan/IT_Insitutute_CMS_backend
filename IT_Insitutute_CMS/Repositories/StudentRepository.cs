using IT_Insitutute_CMS.Models.Request;
using Microsoft.Data.Sqlite;

namespace IT_Insitutute_CMS.Repositories
{
    public class StudentRepository: IstudentRepository
    {
        private readonly string _connectionString;
        public studentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void courseselction(string nic, courseSelctionreq coursesel)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Students SET course=@course ,ProficiencyLevels=@ProficiencyLevels,duration=@duration WHERE Nic == @Nic";
                command.Parameters.AddWithValue("@Nic", nic);
                command.Parameters.AddWithValue("@course", coursesel.course);
                command.Parameters.AddWithValue("@ProficiencyLevels", coursesel.ProficiencyLevels);
                command.Parameters.AddWithValue("@duration", coursesel.duration);
                command.ExecuteNonQuery();
            }

        }
    }
}
