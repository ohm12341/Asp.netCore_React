using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.Services
{
    public interface IVitalService
    {
        Task<VitalResponse> SaveVital(Vital vital, string token);
        void SetHttpClient(HttpClient httpClient);
        Task<HttpResponseMessage> Get(string token);
    }
}
