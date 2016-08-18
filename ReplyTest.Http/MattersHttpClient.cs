using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReplyTest.Http.Model.Query;

namespace ReplyTest.Http
{
    public class MattersHttpClient : IMattersHttpClient
    {
        #region Static fields and constants

        private const string _baseUrl = "https://data.42matters.com/api/";
        private const string _apiVersion = "v2.0/";
        private const string _platform = "android/apps/";
        private const string _accessToken = "800f9d6e76f8c8ad17d21bd4a90f7cb9e38575bc";

        #endregion

        #region Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructors

        public MattersHttpClient()
        {
            _httpClient = new HttpClient();
        }

        #endregion

        #region Public methods

        public async Task<AppsResponse> GetTopRatedAppsAsync(int count)
        {
            var url = GetUrl("query.json");
            var request = new TopRatedRequest()
            {
                Query = new Query()
                {
                    Name = "Most Rated Apps",
                    Platform = "android",
                    Query_Params = new QueryParams()
                    {
                        Sort = "number_ratings",
                        From = 0,
                        Num = count,
                        SortOrder = "desc"
                    }
                }
            };
            var serializedRequest = JsonConvert.SerializeObject(request);
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url, UriKind.RelativeOrAbsolute),
                Content = new StringContent(serializedRequest, Encoding.UTF8, "application/json")
            };

            return await SendRequestMessage<AppsResponse>(message);
        }
        public async Task<AppsResponse> GetSearchResults(string searchString, int limit = 25)
        {
            var url = GetUrl("search.json", new[]
            {
                new KeyValuePair<string, string>("q", searchString),
                new KeyValuePair<string, string>("limit", limit.ToString()), 
            });
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url, UriKind.RelativeOrAbsolute),
            };

            return await SendRequestMessage<AppsResponse>(message);
        }

        #endregion

        #region Private methods
        private string GetUrl(string resource, IEnumerable<KeyValuePair<string, string>> queryParams = null)
        {
            var builder = new StringBuilder($"{_baseUrl}{_apiVersion}{_platform}{resource}?access_token={_accessToken}");
            if (queryParams != null)
            {
                foreach (var keyValuePair in queryParams)
                {
                    builder.AppendFormat($"&{keyValuePair.Key}={keyValuePair.Value}");

                }
            }

            return builder.ToString();
        }

        private async Task<TResponse> SendRequestMessage<TResponse>(HttpRequestMessage message)
        {
            var response = await _httpClient.SendAsync(message);
            var contStr = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsAsync<TResponse>();
        }

        #endregion
    }
}