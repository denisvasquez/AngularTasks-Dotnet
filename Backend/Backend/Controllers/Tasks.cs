using Backend.APITasksManager.Dto;
using Backend.APITasksManager.IRepository;
using Backend.APITasksManager.Requests;
using Backend.APITasksManager.Responses;
using Backend.Requests;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [Route("DeleteTask")]
        public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskRequest request)
        {
            var response = await _tasksRepository.DeleteTask(request);

            if (response == null)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar eliminar la tarea" });
            }

            return Ok(new { message = "Task deleted successfully", request.TaskId});
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest request)
        {
            var response = await _tasksRepository.UpdateTask(request);

            if (response == null)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar actualizar la tarea" });
            }

            return Ok(new { message = "Task created successfully", request.TaskId});
        }

        [Authorize]
        [HttpPost]
        [Route("GetTasksByUser")]
        public async Task<IActionResult> GetTasksByUser([FromBody] GetTasksRequest request)
        {
            var response = await _tasksRepository.GetTasksByUserId(request);

            if (response.UserId == 0)
            {
                return BadRequest(new { message = response.Message });
            }

            return Ok(new { message = $"Tasks user '{request.UserId}'", tasks = response.Tasks });
        }

    }
}
