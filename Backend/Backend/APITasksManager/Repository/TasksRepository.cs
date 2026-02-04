using Backend.APITasksManager.Dto;
using Backend.APITasksManager.IRepository;
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
    }
}
