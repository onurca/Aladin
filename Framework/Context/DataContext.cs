using Framework.Model.Authentication;
using Framework.Model.Logger;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Framework.Context
{
    public class DataContext : DbContext
    {
        public DataContext(string CS) : base(CS)
        {

        }

        #region Tables
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserInRole> UserInRole { get; set; }
        public IDbSet<ViewInRole> ViewInRole { get; set; }
        public IDbSet<Log> Log { get; set; }
        public IDbSet<Info> Info { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
