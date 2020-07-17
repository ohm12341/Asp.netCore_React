using Newtonsoft.Json;

namespace Domain
{
    public class LoginResposne
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("expiresTime")]
        public string ExpiresTime { get; set; }

        public bool IsSucess { get; set; }
    }
}
