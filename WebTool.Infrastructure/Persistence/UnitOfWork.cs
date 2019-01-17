using System;
using System.Collections.Generic;
using WebTool.Core.Interfaces;
using WebTool.Infrastructure.Persistence.Repositories;

namespace WebTool.Infrastructure.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private Dictionary<string, object> repositories;

        private IUserRepository _userRepo;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        // Generic Repository
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _appDbContext);
                repositories.Add(type, repositoryInstance);
            }
            return (IRepository<TEntity>)repositories[type];
        }

        // User Repository
        public IUserRepository UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_appDbContext);
                }
                return _userRepo;
            }
        }

    }
}
