using IT_Insitutute_CMS.Entities;

namespace IT_Insitutute_CMS.IRepositories
{
    public interface IAdminRepository
    {
        void AddStudent(Student student);
        void DeleteStudent(string nic);
    }
}
