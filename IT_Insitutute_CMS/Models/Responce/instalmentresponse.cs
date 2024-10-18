namespace IT_Insitutute_CMS.Models.Responce
{
    public class instalmentresponse
    {
        public string Nic { get; set; }
        public decimal installmentAmount { get; set; }
        public string Installments { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal paymentDue { get; set; }


        public decimal PaymentPaid { get; set; }
        public decimal totalAmount { get; set; }
    }
}
