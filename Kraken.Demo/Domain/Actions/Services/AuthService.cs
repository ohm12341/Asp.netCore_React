using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Domain.Actions.Services
{
    public class AuthService : IAuthService
    {
        private HttpClient client;


        public async Task<LoginResposne> Login(string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "auth");
            return await DoRequest(request, new Login()
            {
                Password = password,
                Username = username
            });
        }

        public async Task<LoginResposne> Register(Login login)
        {

            var request = new HttpRequestMessage(HttpMethod.Post,
           "auth");
            return await DoRequest(request, login);

        }

        public void SetClient(HttpClient httpClient)
        {
            client = httpClient;
        }

        private async Task<LoginResposne> DoRequest(HttpRequestMessage httpRequestMessage, Login login)
        {
            var myContent = JsonConvert.SerializeObject(login);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpRequestMessage.Content = byteContent;


            var response = await client.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<LoginResposne>(responseStream);

                responseData.IsSucess = true;
                return responseData;

            }
            else
            {

                return await Task.FromResult(new LoginResposne()
                {
                    ExpiresTime = string.Empty,
                    Token = String.Empty,
                    UserName = login.Username,
                    IsSucess = false

                });
            }
        }
    }
}
