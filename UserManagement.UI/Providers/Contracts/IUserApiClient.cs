using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.UI.Models;

namespace UserManagement.UI.Providers.Contracts
{
   public interface IUserApiClient
    {
        IEnumerable<UserDetailedViewModel> GetAllUsers();
        UserDetailedViewModel UserDetailsOnLoginBtnClick(string userName, int password);
    }
}
