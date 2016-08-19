using Newtonsoft.Json;

namespace ReplyTest.Model
{
    public class App
    {
        [JsonProperty(PropertyName = "package_name")]
        public string PackageName { get;set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get;set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "downloads")]
        public string Downloads { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "icon_72")]
        public string IconSmall { get; set; }

        [JsonProperty(PropertyName = "short_desc")]
        public string ShortDesc { get; set; }
    }
}
