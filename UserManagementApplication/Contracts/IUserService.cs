﻿using System;
using System.Collections.Generic;
using System.Text;
using UserManagementApplication.Models;

namespace UserManagementApplication.Contracts
{
   public interface IUserService
    {
        IEnumerable<UserData> GetAllUser();
        UserData GetUserById(int id);
        bool InsertUser(UserData user);
        bool UpdateUser(UserData user);
        bool DeleteUser(int id);
        UserData UserDetailsOnLoginBtnClick(string userName, int password);
    }
}
