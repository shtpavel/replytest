using System.Data.Entity;

namespace ReplyTest.Dal.Interfaces
{
    public interface IDataContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}