using System.ComponentModel.DataAnnotations;

namespace TaskBuddy_API.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public string? GoogleUserId { get; set; }

        public string? Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
