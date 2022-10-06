using System;
using BackyardDnD_BackEnd.Models;
using BackyardDnD_BackEnd.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackyardDnD_BackEnd.Controllers
{
    [Route("API/[controller]")]
    [EnableCors("MyPolicy")]
    public class UserController : Controller
    {
        private readonly IUserInterface _createUserInterface;
        public UserController(IUserInterface createUserInterface)
        {
            _createUserInterface = createUserInterface;
        }
        
        [HttpPost]
        [Route("RegisterUser")]
        public bool SaveUser([FromBody] User user)
        {
            try
            {
                _createUserInterface.RegisterUser(user);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        [Route("LoginUser")]
        public bool Login([FromBody] User user)
        {
            var loginStatus = _createUserInterface.LoginUser(user.UserName, user.Password);

            return loginStatus;
        }
    }
}