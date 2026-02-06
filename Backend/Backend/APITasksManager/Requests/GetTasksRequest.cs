using Backend.APITasksManager.Dto;
using Backend.Models;

namespace Backend.APITasksManager.Requests
{
    public class GetTasksRequest
    {
        public int UserId { get; set; }
    }
}
