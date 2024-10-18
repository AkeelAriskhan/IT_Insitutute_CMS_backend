using IT_Insitutute_CMS.Models.Request;

namespace IT_Insitutute_CMS.IRepositories
{
    public interface IStudentRepository
    {
        void courseselction(string nic, courseSelctionreq coursesel);
        void passwordupdate(string password, string nic);

    }
}
