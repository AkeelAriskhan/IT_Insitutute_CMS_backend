using IT_Insitutute_CMS.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IT_Insitutute_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IstudentRepository _istudentRepository;

        public studentcontroller(IstudentRepository istudentRepository)
        {
            _istudentRepository = istudentRepository;
        }
        [HttpPut("course-selection")]
        public IActionResult courseselction(string nic, courseSelctionreq coursesel)
        {
            _istudentRepository.courseselction(nic, coursesel);
            return Ok("Added");

        }
    }
}
