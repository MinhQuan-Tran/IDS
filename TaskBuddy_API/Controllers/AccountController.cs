using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        [HttpPost("GoogleLogin")]
        public async Task<IActionResult> GoogleLogin([FromBody] string credential)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(credential);

            if (payload == null)
            {
                return Unauthorized("Invalid Google credentials!");
            }

            var googleUserId = payload.AudienceAsList.FirstOrDefault();

            // Check if the user already exists in your database
            var foundUser = UserConstants.Users.FirstOrDefault(u => u.GoogleUserId == googleUserId);

            if (foundUser == null)
            {
                // Create a new user if they don't exist
                var newUser = new UserModel()
                {
                    Id = "U-" + Guid.NewGuid().ToString("N"),
                    GoogleUserId = googleUserId,
                    Email = payload.Email,
                    UserName = payload.Name,
                    ProfilePicture = payload.Picture,
                };

                UserConstants.Users.Add(newUser);

                foundUser = newUser;
            }

            // Redirect the user to the specified URL or a default page
            return Ok(new returnUserModel(foundUser));
        }

        [AllowAnonymous]
        [HttpPost("PasswordLogin")]
        public IActionResult PasswordLogin(UserPasswordModel userPasswordModel)
        {
            if (userPasswordModel == null)
            {
                return Unauthorized("Missing user info!");
            }

            var foundUser = UserConstants.Users.FirstOrDefault(u => u.Email == userPasswordModel.Email && u.Password == userPasswordModel.Password);

            if (foundUser == null)
            {
                return Unauthorized("User not found!");
            }

            return Ok(new returnUserModel(foundUser));
        }

        public class UserPasswordModel
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class returnUserModel
        {
            public string UserName { get; set; }
            public string? ProfilePicture { get; set; }
            public returnUserModel(UserModel user)
            {
                UserName = user.UserName;
                ProfilePicture = user.ProfilePicture;
            }

        }
    }
}
