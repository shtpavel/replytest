using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ReplyTest.Dal.Interfaces;
using ReplyTest.Model;

namespace ReplyTest.Dal.Repositories
{
    public class AppsRepository : IAppsRepository
    {
        private readonly IDataContext _dataContext;

        public AppsRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public App Add(App app)
        {
            _dataContext.Set<App>().Add(app);
            _dataContext.SaveChanges();
            return app;
        }

        public IEnumerable<App> All(App app)
        {
            return _dataContext
                .Set<App>()
                .AsEnumerable();
        }

        public virtual IEnumerable<App> GetAllWhere(Expression<Func<App, bool>> predicate)
        {
            return _dataContext
                .Set<App>()
                .Where(predicate);
        }

        public App GetByPackageName(string packageName)
        {
            return _dataContext
                .Set<App>()
                .FirstOrDefault(x => x.PackageName == packageName);
        }
    }
}
