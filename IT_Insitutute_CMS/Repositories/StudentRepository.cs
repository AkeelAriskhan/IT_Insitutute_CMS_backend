namespace IT_Insitutute_CMS.Repositories
{
    public class StudentRepository: IstudentRepository
    {
        private readonly string _connectionString;
        public studentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
