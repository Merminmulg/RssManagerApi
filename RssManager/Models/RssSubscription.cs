using MessagePack;
using System.Net;

namespace RssManager.Models
{
    public class RssSubscription
    {
        public int RssSubscriptionId { get; set; }
        public string? Url { get; set; }

        public List<XmlItemModel> XmlItemModels { get; set; } = new();
    }
}
