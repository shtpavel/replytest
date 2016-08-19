﻿using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ReplyTest.Dal.Interfaces;
using ReplyTest.Http;
using ReplyTest.Http.Interfaces;
using ReplyTest.Model;

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