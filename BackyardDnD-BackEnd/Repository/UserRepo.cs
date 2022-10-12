using System;
using System.Security.Claims;
using BackyardDnD_BackEnd.Database;
using BackyardDnD_BackEnd.Models;
using BackyardDnD_BackEnd.Models.character;
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

        public bool CheckUnique(string userName)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@Username", userName),
                };
                var res = _dataBaseHelper.TriggerStoredProc("spCheckUnique", dataParams);
                if (res.Rows.Count == 0)
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

        public string CreateCharacter(User user)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@UserName", user.UserName),
                }; 
                _dataBaseHelper.TriggerStoredProcNoTable("spCreateCharacter", dataParams);
                
                return "Success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Fail";
            }
        }

        public UserCharacter LoadCharacter(User user)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@userName", user.UserName),
                }; 
                var userCharacter = _dataBaseHelper.TriggerStoredProc("spLoadChar", dataParams);
                
                return _converter.ConvertCharModel(userCharacter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string SendRoll(RollModel rollModel)
        {
            var final = rollModel.RollValue + rollModel.Modifier;
            var result = "================================================\n" + rollModel.Username + " rolled a " + final + ".\nThe Modifier was " +
                         rollModel.Modifier + ".";
            Console.WriteLine(result);
            return result;
        }
    }
}