using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Responce;
using Microsoft.Data.Sqlite;

namespace IT_Insitutute_CMS.Repositories
{
    public class PaymentsRepository: IPaymentRepository
    {
        private readonly string _connectionString;
        public PaymentsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public instalmentresponse getinsallmentbydetailsbynic(string nic)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var coommand = connection.CreateCommand();
                coommand.CommandText = @"select* from installment where Nic=@Nic";
                coommand.Parameters.AddWithValue("@Nic", nic);
                using (var reader = coommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var intallment = new instalmentresponse()
                        {
                            Nic = reader.GetString(0),
                            installmentAmount = reader.GetDecimal(1),
                            Installments = reader.GetString(2),
                            PaymentDate = reader.GetDateTime(3),
                            paymentDue = reader.GetDecimal(4),
                            PaymentPaid = reader.GetDecimal(5),
                            totalAmount = reader.GetDecimal(6),
                        };
                        return intallment;
                    }
                    else
                    {
                        return null;
                    }

                }
            }


        }

    }
}
