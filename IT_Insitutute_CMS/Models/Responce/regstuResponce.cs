namespace IT_Insitutute_CMS.Models.Responce
{
    public class regstuResponce
    {
        public string Nic { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public decimal RegistrationFee { get; set; }
        public string? ImagePath { get; set; }
        public string course { get; set; }

        public string ProficiencyLevels { get; set; }

        public string duration { get; set; }
        public decimal fullpayment { get; set; }
        public DateTime paymentDate { get; set; }
    }
}
