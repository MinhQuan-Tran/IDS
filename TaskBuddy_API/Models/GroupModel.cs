using System.ComponentModel.DataAnnotations;

namespace TaskBuddy_API.Models
{
    public class GroupModel
    {
        [Key, Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<string> TaskIds { get; set; }

        [Required]
        public List<string> UserIds { get; set; }
    }
}