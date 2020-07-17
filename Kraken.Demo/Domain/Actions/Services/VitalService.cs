using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Domain.Actions.Services
{
    public class VitalService : IVitalService
    {

        private HttpClient HttpClient;


        public async Task<VitalResponse> SaveVital(Vital vital, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
     "HumanVitals");


            var myContent = JsonConvert.SerializeObject(vital);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            request.Content = byteContent;

            HttpClient.DefaultRequestHeaders.Authorization =
      new AuthenticationHeaderValue("Bearer", token);

            var response = await HttpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(new VitalResponse() { IsSucess = true, Message = string.Empty });
            }
            else
            {
                return await Task.FromResult(new VitalResponse() { IsSucess = false, Message = string.Empty });

            }
        }

        public async Task<HttpResponseMessage> Get(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
      "HumanVitals/3790026f-0eeb-494a-8fe7-d4c616f7eacd");


            HttpClient.DefaultRequestHeaders.Authorization =
      new AuthenticationHeaderValue("Bearer", token);

            return await HttpClient.SendAsync(request);

            
        }
        public void SetHttpClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }
    }
}
