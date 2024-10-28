using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Models.Request;
using IT_Insitutute_CMS.Models.Responce;
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
        [HttpGet("getinstalmentdetails")]
        public IActionResult instamentpaymentdetails()
        {
            var paymrntdetais = _paymentRepository.instamentpaymentdetails();
            return Ok(paymrntdetais);

        }
        [HttpGet("get-installment-details-by-id")]
        public IActionResult getinsallmentbydetailsbynic(string nic)
        {
            var paymrntdetais=_paymentRepository.getinsallmentbydetailsbynic(nic);
            return Ok(paymrntdetais);
        }


    }
}
