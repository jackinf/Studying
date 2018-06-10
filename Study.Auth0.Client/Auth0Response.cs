using Newtonsoft.Json;

namespace Study.Auth0.Client
{
    class Auth0Response
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}