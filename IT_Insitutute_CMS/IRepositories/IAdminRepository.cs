using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.Models.Request;

namespace IT_Insitutute_CMS.IRepositories
{
    public interface IAdminRepository
    {
        void AddStudent(Student student);
        void DeleteStudent(string nic);
        void UpdateStudent(studentupdateRequest student);

    }
}
