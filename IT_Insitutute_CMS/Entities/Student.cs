namespace IT_Insitutute_CMS.Entities
{
    public class Student
    {
        public string Nic { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public decimal RegistrationFee { get; set; }
        public string? ImagePath { get; set; }
    }
}
