using Microsoft.Data.Sqlite;

namespace IT_Insitutute_CMS.Database
{
    public class DatabaseInitializer
    {
        private string _connectionString;

        public DatabaseInitializer(string? connectionString)
        {
            _connectionString = connectionString;
        }
        public void Initialize()
        {
            Console.WriteLine("Running DatabaseInitializer Initialize Fuction...");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        Nic  NVARCHAR(30) PRIMARY KEY,
                        FullName NVARCHAR(30) NOT NULL,
                        Email NVARCHAR(30) NOT NULL,
                        PhoneNumber NVARCHAR(30) NOT NULL,
                        Password NVARCHAR(30) NOT NULL,
                        RegistrationFee decimel NOT NULL,
                        ImagePath NVARCHAR(100) NULL,
                        course NAVCHAR(30),
                        ProficiencyLevels NAVCHAR(30),
                        duration NAVCHAR(30),
                        fullpayment decimel,
                        paymentDate DATE

                    );
                    CREATE TABLE IF NOT EXISTS Courses(
                       CourseID INTEGER PRIMARY KEY,
                       CourseName NAVCHAR(30) ,
                       ProficiencyLevel NAVCHAR(30),
                       CourseFee INTEGER NOT NULL


                     );
                    CREATE TABLE IF NOT EXISTS installment(
                          
                           Nic NAVCHAR(50) ,
                           installmentAmount decimel,
                           Installments NAVCHAR(30), 
                           PaymentDate DATE,
                           paymentDue decimel,
                           PaymentPaid decimel,
                           totalAmount decimel  
                                       
                     );    
            
                    CREATE TABLE IF NOT EXISTS Notifications(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nic NVARCHAR(15) NOT NULL,
                        Type NVARCHAR(50) NOT NULL,
                        SourceId NVARCHAR(50) NOT NULL,
                        Date Date NOT NULL,
                        IsDeleted BOOLEAN

                    );

                        CREATE TABLE IF NOT EXISTS ContactUS(
                        Id INT PRIMARY KEY,
                        Name NVARCHAR(50) NOT NULL,
                        Email NVARCHAR(50) NOT NULL,
                        Message NVARCHAR(500) NOT NULL,
                        SubmitDate Date NOT NULL
                    );

                    PRAGMA foreign_keys = ON;

                ";
                command.ExecuteNonQuery();
            }
        }
    }

}

