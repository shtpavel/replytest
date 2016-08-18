using Newtonsoft.Json;

namespace ReplyTest.Http.Model.Query
{
    public class Query
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "platform")]
        public string Platform { get; set; }

        [JsonProperty(PropertyName = "query_params")]
        public QueryParams Query_Params { get; set; }
    }
}