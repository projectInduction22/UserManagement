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
      /*  [Route("login-page")]*/
        public IActionResult LoginPage()
        {
            return View();
        }
        
        /*[HttpGet]
        public IActionResult LoginPage(string userName, int password)
        {
            if (userName == "Admin" && password == 12345)
            {
                return RedirectToAction("GetAllUser", "admin-page");
            }
            else
            {
                return RedirectToAction("UserDetailsOnLoginBtnClick", "user-page/{userName}/{password}");
            }
        }*/
        /*[Route("user-page/{userName}/{password}")]*/
        public IActionResult UserDetailsOnLoginBtnClick(string userName, int password)
        {
            try
            {
                var details = _userApiClient.UserDetailsOnLoginBtnClick(userName,password);
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

      


    }
}
