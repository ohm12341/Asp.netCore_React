using Newtonsoft.Json;

namespace Domain
{
    public class Vital
    {
        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }
        [JsonProperty("businessUnitId")]
        public string BusinessUnitId { get; set; }
        [JsonProperty("deviceId")]
        public string deviceId { get; set; }
        [JsonProperty("heartRate")]
        public int HeartRate { get; set; }

        [JsonProperty("temperature")]
        public float Temperature { get; set; }
    }
}
