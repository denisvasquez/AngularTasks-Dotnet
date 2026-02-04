using Backend.Models;

namespace Backend.Responses
{
    public class GetAllTasksResponse
    {
        public string? Message { get; set; }
        public List<Tasks> Tasks { get; set; } = new();
    }
}
