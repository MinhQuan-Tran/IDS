using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TaskBuddy_API.Models;

namespace TaskBuddy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet("GoogleCallback")]
        public async Task<IActionResult> GoogleCallback(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                return Unauthorized("Authentication not success!");
            }

            var userEmail = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
            var userName = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name);
            var googleUserId = authenticateResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userEmail.DefaultIfEmpty() == null || userName.DefaultIfEmpty() == null || googleUserId.DefaultIfEmpty() == null)
            {
                return Unauthorized("Missing email, user name or user id!");
            }

            // Check if the user already exists in your database
            var existingUser = UserConstants.Users.FirstOrDefault(u => u.GoogleUserId == googleUserId);

            if (existingUser == null)
            {
                // Create a new user if they don't exist
                var newUser = new UserModel()
                {
                    Id = "U-" + Guid.NewGuid().ToString("N"),
                    GoogleUserId = googleUserId,
                    Email = userEmail,
                    UserName = userName,
                };

                UserConstants.Users.Add(newUser);
            }

            // Redirect the user to the specified URL or a default page
            return LocalRedirect(returnUrl);
        }

        [AllowAnonymous]
        [HttpGet("PasswordLogin")]
        public IActionResult PasswordLogin(UserLogin userLogin)
        {
            if (userLogin == null)
            {
                return Unauthorized("Missing user info!");
            }

            var foundUser = UserConstants.Users.FirstOrDefault(u => u.Email == userLogin.Email && u.Password == userLogin.Password);

            if (foundUser == null)
            {
                return Unauthorized("User not found!");
            }

            return Ok(foundUser);
        }

        public class UserLogin
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }
}
