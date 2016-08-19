using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplyTest.Model;

namespace ReplyTest.Dal.Configurations
{
    internal class AppsModelDatabaseConfiguration : EntityTypeConfiguration<App>
    {
        public AppsModelDatabaseConfiguration()
        {
            ToTable("Apps");
            HasKey(x => x.PackageName);
        }
    }
}
