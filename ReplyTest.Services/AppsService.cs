using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ReplyTest.Dal.Interfaces;
using ReplyTest.Http;
using ReplyTest.Http.Interfaces;
using ReplyTest.Model;
using ReplyTest.Model.ViewModels;

namespace ReplyTest.Services
{
    public class AppsService : IAppsService
    {
        #region Fields

        private readonly IMattersHttpClient _client;
        private readonly IAppsRepository _repository;

        #endregion

        #region Constructors

        public AppsService(
            IMattersHttpClient client,
            IAppsRepository repository)
        {
            _client = client;
            _repository = repository;
        }

        #endregion

        #region Public methods

        public async Task<App[]> GetTopRatedApps(int count)
        {
            var apps = await _client.GetTopRatedAppsAsync(count);
            SaveAppsToLocalStorage(apps);

            return apps.Results;
        }

        public async Task<App> GetByPackageIdAsync(string package)
        {
            var app = await _repository.GetAllWhereAsync(x => x.PackageName == package);
            return app.FirstOrDefault();
        }

        public async Task<App[]> GetAllAsync()
        {
            var apps = await _repository.GetAllWhereAsync(x => true);
            return apps;
        }

        public PagedResult<App> GetAllAsync(int page, int itemsPerPage)
        {
            var apps =  _repository.GetAllAsQueryable();

            var count = apps.Count();
            var pagesCount = count/itemsPerPage;
            var result = apps
                .OrderBy(x => x.Title)
                .Skip(page*itemsPerPage)
                .Take(itemsPerPage);

            return new PagedResult<App>
            {
                CurrentPage = page,
                Data = result.ToArray(),
                TotalPages = pagesCount
            };
        }

        public async Task<App[]> SearchAppsAsync(string pattern, int limit)
        {
            var formattedPattern = pattern
                .ToLower(CultureInfo.InvariantCulture)
                .Trim();
            var apps = await _client.GetSearchResults(formattedPattern, limit);
            SaveAppsToLocalStorage(apps);

            return apps.Results;
        }

        #endregion

        #region Private methods

        private void SaveAppsToLocalStorage(AppsResponse apps)
        {
            foreach (var app in apps.Results)
            {
                if (_repository.GetAllWhere(x => x.PackageName == app.PackageName).Any())
                    continue;

                _repository.Add(app);
            }
        }

        #endregion
    }
}