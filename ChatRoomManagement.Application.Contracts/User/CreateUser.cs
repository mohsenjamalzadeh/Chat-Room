using _01_framework.Application;
using Microsoft.AspNetCore.Http;

namespace ChatRoomManagement.Application.Contracts.User
{
    public class CreateAccount
    {
        public string Name { get;  set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public IFormFile Picture { get; set; }
    }

    public class EditAccount:CreateAccount
    {
        public int Id { get; set; }
    }

    public interface IUserApplication
    {
        OperationResult CreateAccount(CreateAccount command);
        OperationResult EditAccount(EditAccount command);

    }
}
