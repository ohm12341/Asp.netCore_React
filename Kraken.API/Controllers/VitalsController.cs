using Domain;
using Domain.Actions.Services;
using Kraken.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kraken.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IVitalService vitalService;

        public VitalsController(IHttpClientFactory clientFactory, IVitalService vitalService)
        {

            this.clientFactory = clientFactory;
            this.vitalService = vitalService;
        }
        // GET: api/<VitalsController>


        // GET api/<VitalsController>/5
        [HttpGet]
        public async Task<object> Get(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return new WebException("Invalid Token");
            }
            var client = clientFactory.CreateClient("kraken");
            vitalService.SetHttpClient(client);
            var response = await vitalService.Get(token);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await System.Text.Json.JsonSerializer.DeserializeAsync<object>(responseStream);
            }
            else
            {
                return Task.CompletedTask;

            }

        }

        // POST api/<VitalsController>
        [HttpPost]
        public async Task<VitalResponse> Post(VitalsViewModel vitals)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
           "HumanVitals");

            Vital vitalsModel = new Vital()
            {
                OrganizationId = "3790026f-0eeb-494a-8fe7-d4c616f7eacd",
                BusinessUnitId = vitals.BusinessUnitId,
                deviceId = vitals.deviceId,
                HeartRate = int.Parse(vitals.HeartRate),
                Temperature = float.Parse(vitals.Temperature)

            };



            var client = clientFactory.CreateClient("kraken");
            vitalService.SetHttpClient(client);
            return await vitalService.SaveVital(vitalsModel, vitals.Token);


        }

        // PUT api/<VitalsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VitalsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
