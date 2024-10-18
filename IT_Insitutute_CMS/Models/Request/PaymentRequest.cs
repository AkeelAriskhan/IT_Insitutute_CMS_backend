namespace IT_Insitutute_CMS.Models.Request
{
    public class PaymentRequest
    {
        public string Nic { get; set; }
        public int courseFee { get; set; }
        public string paymentPlans { get; set; }
        public int totalamount { get; set; }
        public string Installments { get; set; }
    }
}
