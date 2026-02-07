namespace Backend.APITasksManager.Responses
{
    public class LoginResponse
    {
        public int? UserId { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}
