using System;
using System.Data;
using BackyardDnD_BackEnd.Models;

namespace BackyardDnD_BackEnd.Database
{
    public class Converter
    {
        public User ConvertUserModel(DataTable dtUser)
        {
            User user = new User();
            foreach (DataRow itemRow in dtUser.Rows)
            {
                user.UserName = itemRow["userName"].ToString();
                user.Email = itemRow["email"].ToString();
                user.Password = itemRow["password"].ToString();
            }

            return user;
        }
    }
}