namespace Backend.Requests
{
    public class CreateTaskRequest
    {
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
