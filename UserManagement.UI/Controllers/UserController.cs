using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.UI.Models;
using UserManagement.UI.Providers.Contracts;

namespace UserManagement.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            this._userApiClient = userApiClient;
        }
        
       
        public IActionResult GetAllUser()
        {
            try
            {
                var users = _userApiClient.GetAllUsers();
                return View(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [Route("login-page")]
        public IActionResult LoginPage()
        {
            return View();
        }
    }
}
