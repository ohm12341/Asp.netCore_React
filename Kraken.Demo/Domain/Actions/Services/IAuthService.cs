using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Actions.Services
{
    public interface IAuthService
    {
        Task<LoginResposne> Login(string username, string password);
        Task<LoginResposne> Register(Login login);

        void SetClient(HttpClient httpClient);

    }
}
