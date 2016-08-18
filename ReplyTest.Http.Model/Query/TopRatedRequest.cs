using Newtonsoft.Json;

namespace ReplyTest.Http.Model.Query
{
    public class TopRatedRequest
    {
        [JsonProperty(PropertyName = "query")]
        public Query Query { get; set; }
    }
}