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
        /*[Route("admin-page")]*/
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
       /* [Route("userDetails/{userId}")]*/
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var userDetailsById = _userApiClient.GetUserById(userId);
                return View(userDetailsById);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*[Route("login-page")]*/
        public IActionResult LoginPage()
        {
            return View();
        }


        /* [Route("user-page/{userName}/{password}")]*/
        public IActionResult UserDetailsOnLoginBtnClick(string userName, int password)
        {
            try
            {
                var details = _userApiClient.UserDetailsOnLoginBtnClick(userName, password);
                if (userName == "Admin" && password == 12345)
                {
                    return RedirectToAction("GetAllUser", "User");
                }
                else 
                {
                    return View(details);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult UpdateUser(int userId)
        {
            var user = _userApiClient.GetUserById(userId);
            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateUser(UserDetailedViewModel updation)
        {
            var updateUser = _userApiClient.UpdateUser(updation);
            return RedirectToAction("GetAllUser", "User");
        }

        /*   [Route("signup-page")]*/
        public IActionResult InsertUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertUser(UserViewModel user)
        {
            var insertUser = _userApiClient.InsertUser(user);
            return RedirectToAction("LoginPage", "User");
        }

        public IActionResult DeleteUser(int userId)
        {           
            _userApiClient.DeleteUser(userId);
            return RedirectToAction("GetAllUser", "User");
        }

       
    }
}
