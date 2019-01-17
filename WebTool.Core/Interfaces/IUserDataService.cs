using System.Collections.Generic;
using System.Threading.Tasks;
using WebTool.Core.ViewModels;

namespace WebTool.Core.Interfaces
{
    public interface IUserDataService
    {
        Task<IEnumerable<UserViewModel>> GetUserList();
    }
}
