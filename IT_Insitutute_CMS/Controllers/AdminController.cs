using IT_Insitutute_CMS.IRepositories;
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
    }
}
