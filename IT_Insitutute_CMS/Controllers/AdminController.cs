using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Insitutute_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IAdminRepository adminRepository, IWebHostEnvironment webHostEnvironment)
        {
            _adminRepository = adminRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Add-Student")]
        public async Task<IActionResult> AddStudent(StudentRequest addStudent)
        {
            var StudentObj = new Student()
            {
                Nic = addStudent.Nic,
                FullName = addStudent.FullName,
                Email = addStudent.Email,
                PhoneNumber = addStudent.PhoneNumber,
                Password = addStudent.Password,
                RegistrationFee = addStudent.RegistrationFee,

            };

            if (addStudent.ImageFile != null && addStudent.ImageFile.Length > 0)
            {

                if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
                {
                    throw new ArgumentNullException(nameof(_webHostEnvironment.WebRootPath), "WebRootPath is not set. Make sure the environment is configured properly.");
                }

                var profileimagesPath = Path.Combine(_webHostEnvironment.WebRootPath, "profileimages");


                if (!Directory.Exists(profileimagesPath))
                {
                    Directory.CreateDirectory(profileimagesPath);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(addStudent.ImageFile.FileName);
                var imagePath = Path.Combine(profileimagesPath, fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await addStudent.ImageFile.CopyToAsync(stream);
                }


                StudentObj.ImagePath = "/profileimages/" + fileName;
            }
            else
            {
                StudentObj.ImagePath = null;
            }
            _adminRepository.AddStudent(StudentObj);
            return Ok(StudentObj);
        }
        [HttpDelete("Delete-Students")]
        public IActionResult DeleteStudent(string nic)
        {
            _adminRepository.DeleteStudent(nic);
            return Ok("Deleted");
        }

        [HttpPut("Update-Student")]
        public IActionResult UpdateStudent(studentupdateRequest student)
        {
            _adminRepository.UpdateStudent(student);
            return Ok(student);
        }

        [HttpGet("get-All-Students")]
        public IActionResult getregstudents()
        {
            var students = _adminRepository.getregstudents();
            return Ok(students);
        }
    }
}
