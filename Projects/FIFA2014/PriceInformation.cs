using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA2014
{
    public class PriceInformation
    {
        [JsonProperty("xb")]
        public int Xbox { get; set; }
        [JsonProperty("ps")]
        public int PS { get; set; }
        [JsonProperty("pc")]
        public int PC { get; set; }
    }
}
