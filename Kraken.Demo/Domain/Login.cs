using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Login
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
