using Newtonsoft.Json;

namespace ReplyTest.Http.Model.Query
{
    public class AppsResponse
    {
        [JsonProperty(PropertyName = "number_results")]
        public string NumberResults { get; set; }

        [JsonProperty(PropertyName = "results")]
        public App[] Results { get; set; }
    }
}