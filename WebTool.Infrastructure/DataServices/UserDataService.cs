using System.Collections.Generic;
using System.Linq;
using WebTool.Core.Entities;
using WebTool.Core.Interfaces;
using WebTool.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebTool.Infrastructure.EntityServices
{
    public class UserDataService: IUserDataService
    {
        private readonly IUnitOfWork _unitOfWOrk;

        public UserDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public async Task<IEnumerable<UserViewModel>> GetUserList()
        {
            var users = await _unitOfWOrk.GetRepository<User>()
                .Where(x => x.IsDeleted);

            IEnumerable<UserViewModel> userList = null;
            if (users != null)
            {
                userList = users.Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }).ToList();
            }

            return userList;
        }
    }
}
