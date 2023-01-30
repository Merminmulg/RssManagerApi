using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RssManager.Models;
using System.Text;
using RssManager.Database;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using RssManager.Authorization;
using NuGet.Protocol.Plugins;
using System.Net;
using System.Collections;

namespace RssManager.Contollers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class XmlItemModelsController : ControllerBase
    {
        private readonly Database.XmlContext _context;

        public XmlItemModelsController(Database.XmlContext context, JwtAuthenticationManager jwtAuthenticationManager)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _context = context;
        }

        [Authorize]
        [HttpPost("SetNewsAsReaded")]
        public IActionResult SetNewsAsReaded(int newsId)
        {
            if (_context.XmlItems.FirstOrDefault(n => n.XmlItemModelId == newsId) == null)
            {
                return BadRequest("News doesnt exist");
            }
            User user = _context.Users.First(u => u.Login == HttpContext.User.Identity.Name);
            XmlItemModel news = _context.XmlItems.FirstOrDefault(n => n.XmlItemModelId == newsId);
            user.Items.Add(news);
            _context.SaveChanges();
            return Ok();
        }

        [Authorize]
        [HttpGet("AllSubscribedRssFeeds")]
        public async Task<ActionResult<IEnumerable<RssSubscription>>> GetXmlItems()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        [Authorize]
        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<XmlItemModel>>> GetXmlItemModel(string date)
        {   
            var dateTime = DateTime.Parse(date);
            User user = _context.Users.Include(i=>i.Items).First(u => u.Login == HttpContext.User.Identity.Name);
            var readedItems = _context.Users.First(u => u.Login == HttpContext.User.Identity.Name).Items.ToList();
            if (readedItems == null)
            {
                return await (from item in _context.XmlItems
                       where item.PDate > dateTime
                       select item).ToListAsync();
            }
            var itemsFromDate = (from item in _context.XmlItems
                                where item.PDate > dateTime select item).ToList();
            var itemsWithoutReaded = itemsFromDate.Except(readedItems).ToList();
            return itemsWithoutReaded;
        }

        [Authorize]
        [HttpPost("{uri}")]
        public async Task<ActionResult<XmlItemModel>> PostXmlItemModel(string uri)
        {
            if (uri == null)
            {
                return BadRequest();
            }
            try
            {
                var uriDecoded = HttpUtility.UrlDecode(uri, Encoding.UTF8);
                _context.AddSubscription(uriDecoded);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(uri);
        }
    }
}
