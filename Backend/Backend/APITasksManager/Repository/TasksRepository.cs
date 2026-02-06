using Backend.APITasksManager.Dto;
using Backend.APITasksManager.IRepository;
using Backend.APITasksManager.Requests;
using Backend.APITasksManager.Responses;
using Backend.Data;
using Backend.Models;
using Backend.Requests;
using Microsoft.EntityFrameworkCore;

namespace Backend.APITasksManager.Repository
{
    public class TasksRepository : ITasksRepository
    {
        public readonly AppDbContext _dbContext;

        public TasksRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateTaskResponse> CreateTask(CreateTaskRequest task)
        {
            if (task.Title == null || task.UserId == 0)
            {
                return new CreateTaskResponse()
                {
                    Message = "Ocurrió un error al crear una tarea",
                    TaskId = 0
                };
            }

            // buscar tareas con nombre igual
            Tasks tasksSameName = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Title == task.Title && t.UserId == task.UserId);

            if (tasksSameName != null) 
            {
                return new CreateTaskResponse()
                {
                    Message = "A task with the same title already exists for this user",
                    TaskId = 0
                };
            }

            Tasks newTask = new Tasks()
            {
                Title = task.Title,
                Description = task.Description,
                UserId = task.UserId,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                UpdatedDate = null
            };

            await _dbContext.Tasks.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();

            return new CreateTaskResponse()
            {
                Message = "Task created successfully"
            };
        }

        public async Task<string> DeleteTask(DeleteTaskRequest request)
        {
            if (request.TaskId == 0)
            {
                return null;
            }

            Tasks taskToDelete = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == request.TaskId);

            if (taskToDelete == null)
            {
                return null;
            }

            taskToDelete.Active = false;

            _dbContext.Tasks.Update(taskToDelete);

            await _dbContext.SaveChangesAsync();

            return "Task deleted successfully";
        }

        public async Task<string> UpdateTask(UpdateTaskRequest request)
        {
            if (request.TaskId == 0)
            {
                return null;
            }

            Tasks taskToUpdate = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == request.TaskId);

            if (taskToUpdate == null)
            {
                return null;
            }

            taskToUpdate.Title = request.Title ?? taskToUpdate.Title;
            taskToUpdate.Description = request.Description ?? taskToUpdate.Description;
            taskToUpdate.IsCompleted = request.IsCompleted ?? taskToUpdate.IsCompleted;
            taskToUpdate.UpdatedDate = DateTime.Now;

            _dbContext.Tasks.Update(taskToUpdate);

            await _dbContext.SaveChangesAsync();

            return "Task updated successfully";
        }

        public async Task<GetTasksResponse> GetTasksByUserId(GetTasksRequest request)
        {
            //if (request.UserId == 0)
            //{
            //    return null;
            //}

            //var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId && u.Active == true);

            //if (user == null)
            //{
            //    return null;
            //}

            //var tasks = await _dbContext.Tasks
            //    .Where(t => t.UserId == request.UserId && t.Active == true)
            //    .Select(t => new Tasks
            //    {
            //        Id = t.Id,
            //        Title = t.Title,
            //        Description = t.Description,
            //        CreatedAt = t.CreatedAt,
            //        UpdatedDate = t.UpdatedDate,
            //        IsCompleted = t.IsCompleted
            //    })
            //    .ToListAsync();

            return new GetTasksResponse();
        }
    }
}
