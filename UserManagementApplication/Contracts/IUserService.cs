using System;
using System.Collections.Generic;
using System.Text;
using UserManagementApplication.Models;

namespace UserManagementApplication.Contracts
{
   public interface IUserService
    {
        IEnumerable<UserData> GetAllUsers();
        UserData GetUserById(int userId);
        bool InsertUser(UserData user);
        bool UpdateUser(UserData user);
        bool DeleteUser(int userId);
        UserData UserDetailsOnLoginBtnClick(string userName, int password);
    }
}
