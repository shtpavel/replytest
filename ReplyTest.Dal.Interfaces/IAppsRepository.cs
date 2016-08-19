using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ReplyTest.Model;

namespace ReplyTest.Dal.Interfaces
{
    public interface IAppsRepository
    {
        App Add(App app);
        IEnumerable<App> GetAll();
        IEnumerable<App> GetAllWhere(Expression<Func<App, bool>> predicate);
        //Dangerous for use. 
        IQueryable<App> GetAllAsQueryable();
        Task<App[]> GetAllWhereAsync(Expression<Func<App, bool>> predicate);
    }
}