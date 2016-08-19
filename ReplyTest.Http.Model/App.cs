using System;
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

        [JsonProperty(PropertyName = "cat_key")]
        public string CategoryKey { get; set; }

        [JsonProperty(PropertyName = "downloads")]
        public string Downloads { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "icon_72")]
        public string IconSmall { get; set; }

        [JsonProperty(PropertyName = "short_desc")]
        public string ShortDesc { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public double Rating { get; set; }

        [JsonProperty(PropertyName = "number_ratings")]
        public int NumberRating { get; set; }

        [JsonProperty(PropertyName = "screenshots")]
        public string[] Screenshots { get; set; }

        [JsonProperty(PropertyName = "market_update")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty(PropertyName = "developer")]
        public string Developer { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }
}
