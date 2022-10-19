using System;
using System.Collections.Generic;
using System.Text;
using UserManagementDataAccess.Models;

namespace UserManagementDataAccess.Contracts
{
   public interface IUserRepository
    {
        IEnumerable<UserDetails> GetAllUsers();
        UserDetails GetUserById(int id);
        bool DeleteUser(int id);
        bool InsertUser(UserDetails user);
        bool UpdateUser(UserDetails user);
        UserDetails UserDetailsOnLoginBtnClick(string userName, int password);
    }
}
