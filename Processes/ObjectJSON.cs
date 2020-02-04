using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace TikTak.Processes
    {
    public partial class JObject
    {
        [JsonProperty("MyBest")]
        public Dictionary<string, List<string>> Preferred { get;  }
        [JsonProperty("NetWorkAndActions")]
        public Dictionary<string, List<string>> NetWorkAndActions { get; }
        

    }

        public partial class JObject
        {
        public static JObject FromJson(string json) => JsonConvert.DeserializeObject<JObject>(json);
             
    }

}
