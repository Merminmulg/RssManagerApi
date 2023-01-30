using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RssManager.Authorization;
using RssManager.Models;
using System.Text;

namespace RssManager.Contollers
{
    public class AuthenticationController : Controller
    {
        private readonly Database.XmlContext _context;
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public AuthenticationController(Database.XmlContext context, JwtAuthenticationManager jwtAuthenticationManager)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _context = context;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public IActionResult RegistrateNewAccount(string login, string password)
        {
            if (_context.Users.FirstOrDefault(u => u.Login == login) != null)
            {
                return BadRequest("Login exist");
            }
            _context.Users.Add(new User()
            {
                Password = password,
                Login = login,
                Items = new List<XmlItemModel>(),
            });
            _context.SaveChanges();
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser(string login, string password)
        {
            var token = _jwtAuthenticationManager.Authenticate(login, password, _context.Users.ToList());
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
