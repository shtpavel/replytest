using Newtonsoft.Json;

namespace ReplyTest.Http.Model.Query
{
    public class QueryParams
    {
        [JsonProperty(PropertyName = "sort")]
        public string Sort { get; set; }

        [JsonProperty(PropertyName = "from")]
        public int From { get; set; }

        [JsonProperty(PropertyName = "num")]
        public int Num { get; set; }

        [JsonProperty(PropertyName = "sort_order")]
        public string SortOrder { get; set; }
    }
}