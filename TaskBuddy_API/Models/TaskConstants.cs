namespace TaskBuddy_API.Models
{
    public class TaskConstants
    {
        public static List<TaskModel> Tasks = new List<TaskModel>()
        {
            new TaskModel()
            {
                Id = "T-00000000000000000000000000000000",
                Name = "Task Name",
                Description = "Task Description",
                Status = "Approved",
                AssigneeId = "000000000000000000000",
            }
        };
    }
}