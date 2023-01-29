using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RssManager.Models;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace RssManager.Database
{
    public class XmlContext : DbContext
    {
        public DbSet<XmlItemModel> XmlItems { get; set; } = null;
        public DbSet<RssSubscription> Subscriptions { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public XmlContext(DbContextOptions<XmlContext> options) : base(options)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Database.EnsureCreated();
        }

        public void AddSubscription(string uri)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(uri);
                XmlNodeList? xmlNodes = xmlDoc.SelectNodes("//item");
                List<DateTime> dateTimes = new List<DateTime>();
                List<string> xmlText = new List<string>();
                List<XmlItemModel> xmlItems = new List<XmlItemModel>();
                if (xmlNodes != null)
                    foreach (XmlNode node in xmlNodes)
                    {
                        xmlItems.Add(new XmlItemModel()
                        {
                            XmlText = node.OuterXml,
                            PDate = DateTime.Parse(node.SelectSingleNode(".//pubDate").InnerText),
                        });
                    }
                Subscriptions.Add(new RssSubscription()
                {
                    Url = uri,
                    XmlItemModels = xmlItems,
                });
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        internal Task<ActionResult<XmlDocument>> GetSubscribedFeeds()
        {
            throw new NotImplementedException();
        }
    }
}
