using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserManagement.UI.Models;
using UserManagement.UI.Providers.Contracts;

namespace UserManagement.UI.Providers.ApiClients
{
    public class UserApiClient: IUserApiClient
    {
        private readonly HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<UserDetailedViewModel> GetAllUsers()
        {          
            using (var response = _httpClient.GetAsync("https://localhost:44334/api/users/get-all").Result)
            {
                var users = JsonConvert.DeserializeObject<List<UserDetailedViewModel>>(response.Content.ReadAsStringAsync().Result);

                return users;
            }
        }

        public UserDetailedViewModel UserDetailsOnLoginBtnClick(string userName, int password)
        {

            using (var response = _httpClient.GetAsync("https://localhost:44334/api/users/" + userName + password).Result)
            {
                var userDetails = JsonConvert.DeserializeObject<UserDetailedViewModel>(response.Content.ReadAsStringAsync().Result);

                return userDetails;
            }
        }

    }
}
