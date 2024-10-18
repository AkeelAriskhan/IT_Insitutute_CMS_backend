namespace IT_Insitutute_CMS.Models.Request
{
    public class NotificationRequest
    {
        public string Nic { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public DateTime Date { get; set; }
    }
}
