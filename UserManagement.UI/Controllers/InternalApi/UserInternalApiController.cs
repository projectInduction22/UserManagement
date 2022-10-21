using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.UI.Providers.Contracts;

namespace UserManagement.UI.Controllers.InternalApi
{
    [Route("api/internal/users")]
    [ApiController]
    public class UserInternalApiController : ControllerBase
    {
      
            private readonly IUserApiClient _userApiClient;
            //private object _employeeService;

            public UserInternalApiController(IUserApiClient userApiClient)
            {
            _userApiClient = userApiClient;
            }
            [HttpGet]
            [Route("{userName}/{password}")]
            public IActionResult UserDetailsOnLoginBtnClick([FromRoute] string userName, int password)
            {
                try
                {
                    var userDetails = _userApiClient.UserDetailsOnLoginBtnClick(userName, password);

                    return Ok(userDetails);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
}
