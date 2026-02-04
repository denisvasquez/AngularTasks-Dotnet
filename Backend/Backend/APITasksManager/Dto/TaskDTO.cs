namespace Backend.APITasksManager.Dto
{
    public class TaskDTO
    {
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
