﻿using System;
using System.Collections.Generic;
using System.Text;
using UserManagementApplication.Models;
using UserManagementDataAccess.Contracts;
using UserManagementDataAccess.Models;

namespace UserManagementApplication.Services
{
   public class UserService
   {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserData> GetAllUser()
        {
            var users = _userRepository.GetAllUsers();
            return MapToUserData(users);
        }
        private IEnumerable<UserData> MapToUserData(IEnumerable<UserDetails> users)
        {
            var userList = new List<UserData>();
            foreach (var item in users)
            {
                var user = new UserData
                {
                    UserId = item.UserId,
                    Name = item.Name,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Address = item.Address
                };
                userList.Add(user);
            }
            return userList;
        }

        public UserData GetUserById(int id)
        {
            var userById = _userRepository.GetUserById(id);
            return MapToUserDetails(userById);
        }

        private UserData MapToUserDetails(UserDetails userById)
        {
            return new UserData()
            {
                UserId = userById.UserId,
                Name = userById.Name,
                Email = userById.Email,
                PhoneNumber = userById.PhoneNumber,
                Address = userById.Address
            };
        }

        public bool Insert(UserData user)
        {
            try
            {
                var userData = new UserDetails()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    Password = user.Password
                };
                _userRepository.InsertUser(userData);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateUser(UserData user)
        {
            try
            {
                var userData = new UserDetails()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber
                };
                _userRepository.UpdateUser(userData);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteUser(int ID)
        {
            _userRepository.DeleteUser(ID);
            return true;
        }

        public bool updated(UserData user)
        {
            try
            {
                var userData = new UserDetails()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber
                };
                _userRepository.UpdateUser(userData);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserData UserDetailsOnLoginBtnClick(string userName, int password)
        {
            var userDetailsOnLoginBtnClick = _userRepository.UserDetailsOnLoginBtnClick(userName, password);
            var userLogin = MapToUserData(userDetailsOnLoginBtnClick);
            return userLogin;

        }
        private UserData MapToUserData(UserDetails userLogin)
        {
            var userData = new UserData
            {
                UserId = userLogin.UserId,
                Name = userLogin.Name,
                Email = userLogin.Email,
                PhoneNumber = userLogin.PhoneNumber,
                Address = userLogin.Address
            };

            return userData;
        }
    }
}
