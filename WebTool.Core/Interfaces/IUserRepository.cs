using WebTool.Core.Entities;

namespace WebTool.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        string GetId();
    }
}
