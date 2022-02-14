using Newtonsoft.Json;

namespace CalificationAppWeb.Models
{
    public class B1Session
    {
        [JsonProperty("odata.metadata")]
        public string OdataMetadata { get; set; }
        public string SessionId { get; set; }
        public string Version { get; set; }
        public int SessionTimeout { get; set; }
    }
}
