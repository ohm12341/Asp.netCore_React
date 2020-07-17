using Domain;
using Domain.Actions.Services;
using Kraken.API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kraken.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IHttpClientFactory _clientFactory;
        private readonly IAuthService authService;

        public AuthController(IHttpClientFactory clientFactory, IAuthService authService)
        {
            _clientFactory = clientFactory;
            this.authService = authService;
        }
        // GET: api/<AuthController>

        [HttpGet]
        public async Task<LoginResponseViewmodel> Get(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return await Task.FromResult(new LoginResponseViewmodel()
                {
                    ExpiresTime = "",
                    Token = String.Empty,
                    UserName = username,
                    IsSucess = false

                });
            }

            var loginVM = new Login();
            loginVM.Username = username;
            loginVM.Password = password;

            var client = _clientFactory.CreateClient("kraken");
            authService.SetClient(client);
            var result = await authService.Login(username,password);

            return new LoginResponseViewmodel()
            {
                ExpiresTime = result.ExpiresTime,
                IsSucess = result.IsSucess,
                Token = result.Token,
                UserName = result.UserName
            };
        }

        // GET api/<AuthController>/5

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>

        [HttpPost]
        public async Task<LoginResponseViewmodel> Post([FromBody] LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return await Task.FromResult(new LoginResponseViewmodel()
                {
                    ExpiresTime = "",
                    Token = String.Empty,
                    UserName = model.Username,
                    IsSucess = false

                });
            }

            var loginVM = new Login();
            loginVM.Username = model.Username;
            loginVM.Password = model.Password;

            var client = _clientFactory.CreateClient("kraken");
            authService.SetClient(client);
            var result = await authService.Register(loginVM);

            return new LoginResponseViewmodel()
            {
                ExpiresTime = result.ExpiresTime,
                IsSucess = result.IsSucess,
                Token = result.Token,
                UserName = result.UserName
            };
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
