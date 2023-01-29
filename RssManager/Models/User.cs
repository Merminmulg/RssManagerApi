namespace RssManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<XmlItemModel> Items { get; set; } = new();
    }
}
