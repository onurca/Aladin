using Framework.Context;
using Framework.Core.Caching;
using Framework.Core.Session;
using Framework.Model;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;

namespace Framework
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : AuditableEntity;
        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _dbContext;

        public UnitOfWork(IDataContext dbContext)
        {
            Database.SetInitializer<DbContext>(null);

            _dbContext = dbContext;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : AuditableEntity
        {
           return new Repository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                var modifiedEntries = _dbContext.ChangeTracker.Entries().Where(x => x.Entity is IAuditableEntity
                   && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

                foreach (var entry in modifiedEntries)
                {
                    var entity = entry.Entity as IAuditableEntity;
                    if (entity == null) continue;

                    Guid UserId = Guid.Empty;

                    try { UserId = SessionManager.User.ID; } catch { }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.ID = entity.ID == Guid.Empty ? Guid.NewGuid() : entity.ID;
                            entity.CreatedBy = UserId;
                            entity.CreatedDate = DateTime.Now;
                            entity.UpdatedBy = UserId;
                            entity.UpdatedDate = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            entity.IsDeleted = true;
                            entity.UpdatedBy = UserId;
                            entity.UpdatedDate = DateTime.Now;
                            _dbContext.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            _dbContext.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedBy = UserId;
                            entity.UpdatedDate = DateTime.Now;
                            _dbContext.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            _dbContext.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            break;
                        default:
                            _dbContext.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            _dbContext.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            _dbContext.Entry(entity).Property(x => x.IsDeleted).IsModified = false;
                            break;
                    }
                }

                foreach (var item in modifiedEntries)
                {
                    CacheProvider.Instance.Remove(CacheKey.New(item.Entity));
                }

                return _dbContext.SaveChanges(); 
            }
            catch (DbException Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region IDisposable Members
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
