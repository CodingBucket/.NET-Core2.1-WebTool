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

        public async Task<List<UserViewModel>> GetUserListAsync()
        {
            var users = await _unitOfWOrk.GetRepository<User>()
                .Where(x => !x.IsDeleted)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                })
                .ToListAsync();

            if (users == null)
            {
                users = default(List<UserViewModel>);
            }
            return users;
        }

        public async Task<UserViewModel> GetUserAsync(long userId)
        {
            var user = await _unitOfWOrk.GetRepository<User>()
                .Where(x => x.Id == userId && !x.IsDeleted)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                user = default(UserViewModel);
            }
            return user;
        }
    }
}
