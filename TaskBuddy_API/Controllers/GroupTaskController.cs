using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBuddy_API.Models;

namespace TaskBuddy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupTaskController : ControllerBase
    {
        private IConfiguration _config;
        private IMapper mapperTask;

        public GroupTaskController(IConfiguration config)
        {
            _config = config;

            // Configure AutoMapper mappings (do this once, preferably during application startup)
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskModel, TaskModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            mapperTask = mapperConfig.CreateMapper();
        }

        [HttpGet("AllGroups")]
        public IActionResult AllGroups()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized("User is not authenticated.");
            }

            var userId = GetUserId();

            var foundGroups = GroupConstants.Groups.FindAll(group => group.UserIds.Contains(userId));

            return Ok(foundGroups);
        }

        // Task
        [HttpGet("{groupId}")]
        public IActionResult AllTasks(string groupId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized("User is not authenticated.");
            }

            var userId = GetUserId();

            // Check if group still exists and if user still in that group
            var foundGroup = GroupConstants.Groups.FirstOrDefault(group => group.Id.Equals(groupId) && group.UserIds.Contains(userId));

            if (foundGroup == null)
            {
                return NotFound("Group not found!");
            }

            var foundTasks = TaskConstants.Tasks.FindAll(task => foundGroup.TaskIds.Contains(task.Id));

            return Ok(foundTasks);
        }

        [HttpPost("{groupId}")]
        public IActionResult CreateTask(string groupId, [FromBody] TaskInfo taskInfo)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized("User is not authenticated.");
            }

            if (taskInfo == null)
            {
                return BadRequest("Missing info!");
            }

            var userId = GetUserId();

            // Check if group still exists and if user still in that group
            var foundGroup = GroupConstants.Groups.FirstOrDefault(group => group.Id.Equals(groupId) && group.UserIds.Contains(userId));

            if (foundGroup == null)
            {
                return NotFound("Group not found!");
            }

            TaskModel taskModel = new TaskModel(string.Format("U-{0:N}", Guid.NewGuid().ToString("N")), taskInfo);

            TaskConstants.Tasks.Add(taskModel);

            return Ok(foundGroup);
        }

        [HttpPut("{groupId}")]
        public IActionResult UpdateTask(string groupId, [FromBody] TaskModel taskToUpdate)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized("User is not authenticated.");
            }

            if (taskToUpdate == null)
            {
                return BadRequest("Missing Info!");
            }

            var userId = GetUserId();


            // Check if group still exists and if user still in that group
            var foundGroup = GroupConstants.Groups.FirstOrDefault(group => group.Id.Equals(groupId) && group.UserIds.Contains(userId));

            if (foundGroup == null)
            {
                return NotFound("Group associated the task not found!");
            }

            // Check if task still exists
            var foundTask = TaskConstants.Tasks.FirstOrDefault(task => task.Id.Equals(taskToUpdate.Id));

            if (foundTask == null)
            {
                return NotFound("Task not found!");
            }

            // Update the foundTask with the properties from taskToUpdate
            mapperTask.Map(taskToUpdate, foundTask);

            return Ok(foundGroup);
        }

        [HttpDelete("{groupId}")]
        public IActionResult DeleteTask(string groupId, [FromBody] string taskId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized("User is not authenticated.");
            }

            if (taskId == null)
            {
                return BadRequest("Missing Info!");
            }

            var userId = GetUserId();

            // Check if group still exists and if user still in that group
            var foundGroup = GroupConstants.Groups.FirstOrDefault(group => group.Id.Equals(groupId) && group.UserIds.Contains(userId));

            if (foundGroup == null)
            {
                return NotFound("Group associated the task not found!");
            }

            // Check if task still exists
            var foundTask = TaskConstants.Tasks.FirstOrDefault(task => task.Id.Equals(taskId));

            if (foundTask == null)
            {
                return NotFound("Task not found!");
            }

            TaskConstants.Tasks.Remove(foundTask);

            return Ok($"Task {taskId} deleted!");
        }

        private string GetUserId()
        {
            return this.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

