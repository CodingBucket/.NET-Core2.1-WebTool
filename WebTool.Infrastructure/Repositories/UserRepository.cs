using WebTool.Core.Entities;
using WebTool.Core.Interfaces;

namespace WebTool.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        // Test method
        public string GetId()
        {
            return "get id from user repo";
        }

        //public IEnumerable<User> GetCoursesWithAuthors(int pageIndex, int pageSize)
        //{
        //    return _dbContext.Users
        //        .OrderBy(s => s.FirstName)
        //        .Skip((pageIndex - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();
        //}

    }
}
