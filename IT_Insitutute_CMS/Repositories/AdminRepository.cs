using IT_Insitutute_CMS.IRepositories;

namespace IT_Insitutute_CMS.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
