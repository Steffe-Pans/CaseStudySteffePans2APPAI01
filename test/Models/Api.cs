using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CaseStudy.Models
{
    class Api
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("confirmed")]
        public int Confirmed { get; set; }
        [JsonPropertyName("recovered")]
        public int Recovered { get; set; }
        [JsonPropertyName("critical")]
        public int Critical { get; set; }
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }

    }
}
