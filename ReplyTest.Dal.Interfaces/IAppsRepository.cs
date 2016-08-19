using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ReplyTest.Model;

namespace ReplyTest.Dal.Interfaces
{
    public interface IAppsRepository
    {
        App Add(App app);
        IEnumerable<App> All(App app);
        IEnumerable<App> GetAllWhere(Expression<Func<App, bool>> predicate);
        App GetByPackageName(string packageName);
    }
}