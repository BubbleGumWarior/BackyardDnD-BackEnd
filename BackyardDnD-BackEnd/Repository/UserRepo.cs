using System;
using BackyardDnD_BackEnd.Database;
using BackyardDnD_BackEnd.Models;
using Microsoft.Data.SqlClient;

namespace BackyardDnD_BackEnd.Repository
{
    public class UserRepo : IUserInterface
    {
        
        private readonly DatabaseHelper _dataBaseHelper;
        private readonly Converter _converter;

        public UserRepo(DatabaseHelper dataBaseHelper, Converter converter)
        {
            _dataBaseHelper = dataBaseHelper;
            _converter = converter;
        }


        public string RegisterUser(User user)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@Email", user.Email),
                    new SqlParameter("@Password", user.Password),
                }; 
                _dataBaseHelper.TriggerStoredProcNoTable("spRegisterUser", dataParams);
                return "Success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Fail";
            }
        }

        public bool LoginUser(string username, string password)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };
                var res = _dataBaseHelper.TriggerStoredProc("spLoginUser", dataParams);
                if (res.Rows.Count == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}