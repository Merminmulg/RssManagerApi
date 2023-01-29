namespace RssManager.Models
{
    public class XmlItemModel
    {
        public int XmlItemModelId { get; set; }
        public string? XmlText { get; set; }
        public DateTime PDate { get; set; }

        public int RssSubscriptionId { get; set; }
        public RssSubscription RssSubscription { get; set; }
        public List<User> Users { get; set; } = new();
    }
}
