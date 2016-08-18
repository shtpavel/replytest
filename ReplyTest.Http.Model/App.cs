using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReplyTest.Http.Model
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
    }
}
