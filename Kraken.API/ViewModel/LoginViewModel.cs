using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Kraken.API.ViewModel
{
    public class LoginViewModel
    {

        [JsonProperty("username")]
        [Required]
        [EmailAddress]
        public string Username { get; set; }

       
        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }
    }
}
