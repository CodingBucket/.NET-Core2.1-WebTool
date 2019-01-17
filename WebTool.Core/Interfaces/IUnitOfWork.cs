using System;

namespace WebTool.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IRepository<T> GetRepository<T>() where T : class;

        IUserRepository UserRepo { get; }
    }
}
