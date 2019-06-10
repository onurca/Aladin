using Framework.Context;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Kooperatif.Data
{
    public class KooperatifContext : DataContext, IDataContext
    {
        #region Configuration
        public KooperatifContext() : base(CS)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static string CS
        {
            get
            {
#if DEBUG
                return "Data Source=185.16.237.10\\MSSQLSERVER2014; Initial Catalog=Kooperatif;uid=kooperatif;pwd=5892feysan*;";

                //return "Data Source=185.16.237.10\\MSSQLSERVER2014; Initial Catalog=KooperatifTest;uid=kooperatif;pwd=5892feysan*;";
#else
                return "Data Source=185.16.237.10\\MSSQLSERVER2014; Initial Catalog=Kooperatif;uid=kooperatif;pwd=5892feysan*;";
#endif
            }
        }

        #endregion

        #region Tables
        //public IDbSet<File> Files { get; set; }
        //public IDbSet<Announcement> Announcements { get; set; }
        //public IDbSet<Dues> Dues { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
