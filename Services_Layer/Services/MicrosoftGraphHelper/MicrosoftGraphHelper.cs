using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services_Layer.DTOS.O2Auth;
using Services_Layer.DTOS.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Services.MicrosoftGraphHelper
{
    public class MicrosoftGraphHelper : IMicrosoftGraphHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        //private readonly UserManager<Cust> userManager;
        public MicrosoftGraphHelper(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }
        public async Task<GraphAuthResource> AcquireATokenFromUsernamePasswordAsync(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "client_id", _config.GetValue<string>("AzureAd:ClientId")},
                { "scope",  _config.GetValue<string>("AzureAd:AppScope") },
                { "client_secret", _config.GetValue<string>("AzureAd:ClientSecret") },
                { "username", username },
                { "password", password },
                { "grant_type",_config.GetValue<string>("AzureAd:GrantType") }
            };


            var content = new FormUrlEncodedContent(values);

            var client = _clientFactory.CreateClient();

            var response = await client.PostAsync(_config.GetValue<string>("ADUrl"), content);

            var res = await response.Content.ReadAsStringAsync();

            GraphAuthResource authResource = null;
            authResource = JsonConvert.DeserializeObject<GraphAuthResource>(await response.Content.ReadAsStringAsync());
            return authResource;
        }


        public async Task<GraphAuthResource> AcquireATokenFromRefreshTokenAsync(ReLoginDTO reLoginDTO)
        {

            var values = new Dictionary<string, string>
            {
                { "client_id", _config.GetValue<string>("ADClientId")},
                { "scope",  _config.GetValue<string>("ADAppScope") },
                { "client_secret", _config.GetValue<string>("ADClientSecret") },
                { "refresh_token", reLoginDTO.RefreshToken },

                { "grant_type",_config.GetValue<string>("ADGrantRefreshType") }
            };

            var content = new FormUrlEncodedContent(values);

            var client = _clientFactory.CreateClient();

            var response = await client.PostAsync(_config.GetValue<string>("ADUrl"), content);

            GraphAuthResource authResource = null;
            authResource = JsonConvert.DeserializeObject<GraphAuthResource>(await response.Content.ReadAsStringAsync());
            return authResource;
        }
    }
}
