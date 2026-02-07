using Backend.Models;

namespace Backend.APITasksManager.Responses
{
    public class GetTasksResponse
    {
        public int? UserId { get; set; }
        public string? Message { get; set; }
        public List<Tasks> Tasks { get; set; } = new();
    }
}
