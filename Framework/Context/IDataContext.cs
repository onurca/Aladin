using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Framework.Context
{
    public interface IDataContext
    {
        Database Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbChangeTracker ChangeTracker { get; }
        DbEntityEntry Entry(object entity);
    }
}
