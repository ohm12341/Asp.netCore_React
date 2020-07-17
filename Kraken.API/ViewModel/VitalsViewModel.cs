using Newtonsoft.Json;

namespace Kraken.API.ViewModel
{
  public class VitalsViewModel
  {
    [JsonProperty("organizationId")]
    public string OrganizationId { get; set; }
    [JsonProperty("businessUnitId")]
    public string BusinessUnitId { get; set; }
    [JsonProperty("deviceId")]
    public string deviceId { get; set; }
    [JsonProperty("heartRate")]
    public string HeartRate { get; set; }

    [JsonProperty("temperature")]
    public string Temperature { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }
  }
}
