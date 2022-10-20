using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementDataAccess.Contracts;
using UserManagementDataAccess.Models;

namespace UserManagementDataAccess.Repository
{
   public class UserRepository: IUserRepository
    {
        private SqlConnection _sqlConnection;
        public UserRepository()
        {
            _sqlConnection = new SqlConnection("data source= 10.10.100.68\\SQL2016; database= Dotnet_Core_Training;user id=spsauser;password=$P$@789#;TrustServerCertificate=True");
        }
        public IEnumerable<UserDetails> GetAllUsers()
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "EXEC SP_GET_ALL_USERS", _sqlConnection);
                var sqlDataReader = sqlCommand.ExecuteReader();
                var listOfUsers = new List<UserDetails>();
                while (sqlDataReader.Read())
                {
                    listOfUsers.Add(new UserDetails()
                    {
                        UserId = (int)sqlDataReader["USER_ID"],
                        Name = (string)sqlDataReader["NAME"],
                        Address = (string)sqlDataReader["ADDRESS"],
                        Email = (string)sqlDataReader["EMAIL"],
                        PhoneNumber = (string)sqlDataReader["PHONE_NUMBER"]
                    });

                }
                return listOfUsers;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }


        }
        public UserDetails GetUserById(int id)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "EXEC SP_GET_USER_DETAILS @ID", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", id);
                var sqlDataReader = sqlCommand.ExecuteReader();
                var user = new UserDetails();
                while (sqlDataReader.Read())
                {
                    user.UserId = (int)sqlDataReader["USER_ID"];
                    user.Name = (string)sqlDataReader["NAME"];
                    user.Address = (string)sqlDataReader["ADDRESS"];
                    user.Email = (string)sqlDataReader["EMAIL"];
                    user.PhoneNumber = (string)sqlDataReader["PHONE_NUMBER"];
                }
                return user;

            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "EXEC SP_DELETE_USER @ID", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", id);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public bool InsertUser(UserDetails user)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "EXEC SP_CREATE_USER @NAME,@EMAIL,@ADDRESS,@PHONE_NUMBER,@USER_NAME,@PASSWORD", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("NAME", user.Name);
                sqlCommand.Parameters.AddWithValue("EMAIL", user.Email);
                sqlCommand.Parameters.AddWithValue("ADDRESS", user.Address);
                sqlCommand.Parameters.AddWithValue("PHONE_NUMBER", user.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("USER_NAME", user.UserName);
                sqlCommand.Parameters.AddWithValue("PASSWORD", user.Password);



                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public bool UpdateUser(UserDetails user)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "EXEC SP_UPDATE_USER @ID,@NAME,@EMAIL,@ADDRESS,@PHONE_NUMBER", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", user.UserId);
                sqlCommand.Parameters.AddWithValue("NAME", user.Name);
                sqlCommand.Parameters.AddWithValue("EMAIL", user.Email);
                sqlCommand.Parameters.AddWithValue("ADDRESS", user.Address);
                sqlCommand.Parameters.AddWithValue("PHONE_NUMBER", user.PhoneNumber);
                sqlCommand.ExecuteNonQuery();
                return true;


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public UserDetails UserDetailsOnLoginBtnClick(string userName, int password)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "EXEC SP_GET_USER_LOGIN @USER_NAME,@PASSWORD", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("USER_NAME", userName);
                sqlCommand.Parameters.AddWithValue("PASSWORD", password);
                var sqlDataReader = sqlCommand.ExecuteReader();
                var user = new UserDetails();
                while (sqlDataReader.Read())
                {
                    user.UserId = (int)sqlDataReader["USER_ID"];
                    user.Name = (string)sqlDataReader["NAME"];
                    user.Address = (string)sqlDataReader["ADDRESS"];
                    user.Email = (string)sqlDataReader["EMAIL"];
                    user.PhoneNumber = (string)sqlDataReader["PHONE_NUMBER"];
                }
                return user;

            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
