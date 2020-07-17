using Newtonsoft.Json;
using System;

namespace Kraken.API.ViewModel
{
    public class LoginResponseViewmodel
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
