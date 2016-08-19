using System.Threading.Tasks;
using ReplyTest.Model;
using ReplyTest.Model.ViewModels;

namespace ReplyTest.Services
{
    public interface IAppsService
    {
        Task<App[]> SearchAppsAsync(string pattern, int limit);
        Task<App[]> GetTopRatedApps(int count);
        Task<App> GetByPackageIdAsync(string package);
        PagedResult<App> GetAllAsync(int page, int itemsPerPage);
        Task<App[]> GetAllAsync();
    }
}