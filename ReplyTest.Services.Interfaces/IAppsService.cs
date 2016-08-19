using System.Threading.Tasks;
using ReplyTest.Model;

namespace ReplyTest.Services
{
    public interface IAppsService
    {
        Task<App[]> SearchAppsAsync(string pattern, int limit);
        Task<App[]> GetTopRatedApps(int count);
    }
}