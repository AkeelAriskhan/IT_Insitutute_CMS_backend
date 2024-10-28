using IT_Insitutute_CMS.Entities;
using IT_Insitutute_CMS.Models.Request;
using IT_Insitutute_CMS.Models.Responce;

namespace IT_Insitutute_CMS.IRepositories
{
    public interface IPaymentRepository
    {
        instalmentresponse getinsallmentbydetailsbynic(string nic);

        void fullpayment(Fullpaymentrequest Fullpaymentrequest);
        void instalment(instalmentrequest instalmentrequest);
        void updateinstallment(installmentupdate instalmentrequest);
    }
}
