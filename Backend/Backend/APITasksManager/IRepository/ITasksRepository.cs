using Backend.APITasksManager.Responses;
using Backend.APITasksManager.Requests;
using Backend.Requests;

namespace Backend.APITasksManager.IRepository
{
    public interface ITasksRepository
    {
        public Task<CreateTaskResponse> CreateTask(CreateTaskRequest task);
        public Task<string> DeleteTask(DeleteTaskRequest request);
        public Task<string> UpdateTask(UpdateTaskRequest request);
        public Task<GetTasksResponse> GetTasksByUserId(GetTasksRequest request);
    }
}
