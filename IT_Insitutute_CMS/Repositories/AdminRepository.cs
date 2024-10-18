using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Request;
using IT_Insitutute_CMS.Models.Responce;
using Microsoft.Data.Sqlite;

namespace IT_Insitutute_CMS.Repositories
{
    public class AdminRepository : IAdminRepository
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
        public void DeleteStudent(string nic)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Students where Nic == @Nic ";
                command.Parameters.AddWithValue("@Nic", nic);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(studentupdateRequest student)

        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Students SET FullName=@Fullname ,Email=@Email,PhoneNumber=@PhoneNumber WHERE Nic == @Nic";
                command.Parameters.AddWithValue("@Nic", student.Nic);
                command.Parameters.AddWithValue("@Fullname", student.FullName);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                command.ExecuteNonQuery();
            }

        }

        public ICollection<regstuResponce> getregstudents()
        {

            var studentslist = new List<regstuResponce>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select * from Students ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new regstuResponce()
                        {
                            Nic = reader.GetString(0),
                            FullName = reader.GetString(1),
                            Email = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Password = reader.GetString(4),
                            RegistrationFee = reader.GetDecimal(5),
                            ImagePath = reader.IsDBNull(6) ? null : reader.GetString(6),
                            course = reader.IsDBNull(7) ? null : reader.GetString(7),
                            ProficiencyLevels = reader.IsDBNull(8) ? null : reader.GetString(8),
                            duration = reader.IsDBNull(9) ? null : reader.GetString(9),
                            fullpayment = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                            paymentDate = reader.IsDBNull(11) ? new DateTime(0) : reader.GetDateTime(11),

                        };
                        studentslist.Add(student);
                    }

                }
            }
            return studentslist;
        }
        public regstuResponce getstudentbyNic(string Nic)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select * from Students where Nic=@Nic";
                command.Parameters.AddWithValue("@Nic", Nic);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var student = new regstuResponce()
                        {
                            Nic = reader.GetString(0),
                            FullName = reader.GetString(1),
                            Email = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Password = reader.GetString(4),
                            RegistrationFee = reader.GetDecimal(5),
                            ImagePath = reader.IsDBNull(6) ? null : reader.GetString(6),
                            course = reader.IsDBNull(7) ? null : reader.GetString(7),
                            ProficiencyLevels = reader.IsDBNull(8) ? null : reader.GetString(8),
                            duration = reader.IsDBNull(9) ? null : reader.GetString(9),
                            fullpayment = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                            paymentDate = reader.IsDBNull(11) ? new DateTime(0) : reader.GetDateTime(11),

                        };
                        return student;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }

        public void AddCourse(course course)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Courses(CourseID,CourseName,ProficiencyLevel,CourseFee) VALUES(@CourseID,@CourseName,@ProficiencyLevel,@CourseFee)";
                command.Parameters.AddWithValue("@CourseID", course.courseid);
                command.Parameters.AddWithValue("@CourseName", course.coursename);
                command.Parameters.AddWithValue("@ProficiencyLevel", course.ProficiencyLevel);
                command.Parameters.AddWithValue("@CourseFee", course.courseFee);
                command.ExecuteNonQuery();


            }
        }

        public void DeleteCourse(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Courses where CourseID == @id ";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }


        }

        public void UpdateCourse(int Id, decimal Totalfee)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Courses SET CourseFee=@CourseFee WHERE CourseID == @CourseID";
                command.Parameters.AddWithValue("@CourseID", Id);
                command.Parameters.AddWithValue("@CourseFee", Totalfee);
                command.ExecuteNonQuery();


            }

        }
    }
}
