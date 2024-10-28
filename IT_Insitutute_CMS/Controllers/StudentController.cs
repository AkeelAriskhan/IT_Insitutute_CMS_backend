using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IT_Insitutute_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _istudentRepository;

        public StudentController(IStudentRepository istudentRepository)
        {
            _istudentRepository = istudentRepository;
        }
        [HttpPut("course-selection")]
        public IActionResult courseselction(string nic, courseSelctionreq coursesel)
        {
            _istudentRepository.courseselction(nic, coursesel);
            return Ok("Added");

        }
        [HttpPut("password-Update")]
        public IActionResult passwordupdate(string password, string nic)
        {
            _istudentRepository.passwordupdate(password, nic);
            return Ok("changed");
        }

    }
}
