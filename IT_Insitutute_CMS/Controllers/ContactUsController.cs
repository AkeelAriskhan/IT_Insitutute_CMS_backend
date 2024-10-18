using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Insitutute_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        [HttpPost("Add-ContactUs-Details")]

        public IActionResult AddContactUsDetails(ContactUs contactUs)
        {
            var ContactUsDetails = _contactUsRepository.AddContactUsDetails(contactUs);
            return Ok(ContactUsDetails);
        }
    }
}

