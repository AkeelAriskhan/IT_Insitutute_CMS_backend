namespace IT_Insitutute_CMS.Models.Request
{
    public class instalmentrequest
    {
        public string Nic { get; set; }
        public decimal installmentAmount { get; set; }
        public string Installments { get; set; }
        public decimal paymentDue { get; set; }
        public decimal PaymentPaid { get; set; }
        public decimal totalAmount { get; set; }
    }
}
