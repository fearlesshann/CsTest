using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CsTest.Linq
{
    public class Province
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("cities")]
        public List<City>? Cities { get; set; }
    }

    public class City
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("counties")]
        public List<Area>? Areas { get; set; }
    }

    public class Area
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("circles")]
        public List<Circle>? Circles { get; set; }
    }

    public class Circle
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
