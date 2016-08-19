using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReplyTest.Dal.Configurations;
using ReplyTest.Dal.Interfaces;

namespace ReplyTest.Dal
{
    public class DataContext : DbContext, IDataContext
    {
        #region Constructors

        public DataContext() : base("name=Default")
        {
        }

        #endregion

        #region Public methods

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AppsModelDatabaseConfiguration());
        }
    }
}
