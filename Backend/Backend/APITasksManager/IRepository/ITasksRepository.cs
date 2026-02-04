using Backend.APITasksManager.Responses;
using Backend.Requests;

namespace Backend.APITasksManager.IRepository
{
    public interface ITasksRepository
    {
        public Task<CreateTaskResponse> CreateTask(CreateTaskRequest task);
    }
}
