using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;
using UserManagementApplication.Contracts;
using UserManagementApplication.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserApiController(IUserService userService)
        {          
            this._userService = userService;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAllUser()
        {
            try
            {
                var listOfUsers = _userService.GetAllUsers();
                return Ok(MapToEmployee(listOfUsers));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);

            }
        }
        private IEnumerable<UserDetailedViewModel> MapToEmployee(IEnumerable<UserData> listOfUsers)
        {
            var userList = new List<UserDetailedViewModel>();
            foreach (var item in listOfUsers)
            {
                var employee = new UserDetailedViewModel
                {
                    UserId = item.UserId,
                    Name = item.Name,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Address = item.Address
                };
                userList.Add(employee);
            }
            return userList;
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById([FromRoute] int userId)
        {
            try
            {              
                var user = _userService.GetUserById(userId);
                return Ok(MapUserById(user));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        private UserDetailedViewModel MapUserById(UserData user)
        {
            var userDetails = new UserDetailedViewModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            };
            return userDetails;
        }

        
    }
}
