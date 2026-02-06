using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
