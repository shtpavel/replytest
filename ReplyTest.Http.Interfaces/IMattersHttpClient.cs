using System.Threading.Tasks;
using ReplyTest.Model;

namespace ReplyTest.Http.Interfaces
{
    public interface IMattersHttpClient
    {
        Task<AppsResponse> GetTopRatedAppsAsync(int count);
        Task<AppsResponse> GetSearchResults(string searchString, int limit);
    }
}