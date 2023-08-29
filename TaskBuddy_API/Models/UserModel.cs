using System.ComponentModel.DataAnnotations;

namespace TaskBuddy_API.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; }

        public string GoogleUserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
