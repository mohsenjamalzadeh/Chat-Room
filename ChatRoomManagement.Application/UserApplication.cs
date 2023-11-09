using _01_framework.Application;
using ChatRoomManagement.Application.Contracts.User;
using ChatRoomManagement.Domain.UserAgg;
using WebApiTest;

namespace ChatRoomManagement.Application
{
    internal class UserApplication:IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthHelper _authHelper;
        private readonly ISecurity _security;
        public UserApplication(IUserRepository userRepository, IAuthHelper authHelper,ISecurity security)
        {
            _userRepository = userRepository;
            _authHelper = authHelper;
            _security=security;
        }

        public OperationResult CreateAccount(CreateAccount command)
        {
            var operation=new OperationResult();

            if(_userRepository.IsExist(p=>p.UserName==command.UserName || p.Email==command.Email))
                return operation.Failed("The Account already is exist");

            string password=_security.GetSHA256Hash(command.Password);
            string defulatPicture="https://www.kindpng.com/picc/m/24-248253_user-profile-default-image-png-clipart-png-download.png";
            var user=new User(command.Name,command.Email,command.Name,password,defulatPicture);

            _userRepository.Create(user);
            _userRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult EditAccount(EditAccount command)
        {
            throw new NotImplementedException();
        }
    }
}
