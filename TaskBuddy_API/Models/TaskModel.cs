using System.ComponentModel.DataAnnotations;

namespace TaskBuddy_API.Models
{
    public class TaskInfo
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public string AssigneeId { get; set; }
    }

    public class TaskModel : TaskInfo
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public TaskModel() { }

        public TaskModel(string id, TaskInfo taskInfo)
        {
            this.Id = id;
            this.Description = taskInfo.Description;
            this.Status = taskInfo.Status;
            this.AssigneeId = taskInfo.AssigneeId;
        }
    }
}