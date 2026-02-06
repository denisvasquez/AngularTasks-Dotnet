using Backend.Models;

namespace Backend.APITasksManager.Responses
{
    public class GetTasksResponse
    {
        public List<Tasks> Tasks { get; set; } = new();
    }
}
