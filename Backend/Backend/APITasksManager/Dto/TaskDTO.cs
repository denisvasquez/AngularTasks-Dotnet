namespace Backend.APITasksManager.Dto
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CreatedAt { get; set; }
        public string UpdatedDate { get; set; } = "";
        public bool IsCompleted { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
