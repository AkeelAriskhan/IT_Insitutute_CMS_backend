namespace IT_Insitutute_CMS.Models.Responce
{
    public class NotificationResponse
    {
        public int Id { get; set; }
        public string Nic { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
