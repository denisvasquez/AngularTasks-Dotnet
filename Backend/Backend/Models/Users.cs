using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }
    }
}
