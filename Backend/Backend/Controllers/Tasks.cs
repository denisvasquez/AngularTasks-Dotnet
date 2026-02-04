using Backend.APITasksManager.Dto;
using Backend.APITasksManager.IRepository;
using Backend.APITasksManager.Responses;
using Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tasks : ControllerBase
    {
        public readonly ITasksRepository _tasksRepository;

        public Tasks(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest task)
        {
            var response = await _tasksRepository.CreateTask(task);

            if (response.TaskId == 0)
            {
                return BadRequest(new { message = response.Message });
            }

            return Ok(new { message = "Task created successfully", task });
        }

        [HttpPost]
        [Route("GetTasksByUser")]
        public IActionResult GetTasksByUser([FromBody] GetAllTasksRequest request)
        {
            // Logic to create a task would go here.
            return Ok(new { message = "Tasks" });
        }

    }
}
