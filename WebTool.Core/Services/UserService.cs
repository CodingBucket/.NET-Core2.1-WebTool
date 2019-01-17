using WebTool.Core.Interfaces;
using WebTool.Core.Services.Interfaces;

namespace WebTool.Core.ApplicationService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDataService _userEntityService;

        public UserService(IUnitOfWork unitOfWork, IUserDataService userEntityService)
        {
            _unitOfWork = unitOfWork;
            _userEntityService = userEntityService;
        }

        public int GetUserId()
        {
            // Custom Repository
            var id = _unitOfWork.UserRepo.GetId();
            return 1010;
        }
    }
}
