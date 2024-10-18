﻿using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.Models.Request;
using IT_Insitutute_CMS.Models.Responce;

namespace IT_Insitutute_CMS.IRepositories
{
    public interface IAdminRepository
    {
        void AddStudent(Student student);
        void DeleteStudent(string nic);
        void UpdateStudent(studentupdateRequest student);

        ICollection<regstuResponce> getregstudents();
        regstuResponce getstudentbyNic(string Nic);
        ContactUs AddContactUsDetails(ContactUs contactUs);

    }
}
