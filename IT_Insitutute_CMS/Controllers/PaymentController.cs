using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Insitutute_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpPost("full-payment")]
        public IActionResult fullpayment(Fullpaymentrequest PaymentRequest)
        {
            _paymentRepository.fullpayment(PaymentRequest);
            return Ok("payment paid");
        }
        [HttpPost("installment")]
        public IActionResult instalment(instalmentrequest instalmentrequest)
        {
            _paymentRepository.instalment(instalmentrequest);
            return Ok("instalment paid");
        }
        [HttpPost("instalment-update")]
        public IActionResult updateinstallment(installmentupdate instalmentrequest)
        {
            _paymentRepository.updateinstallment(instalmentrequest);
            return Ok("instalment paid");

        }
    }
}
