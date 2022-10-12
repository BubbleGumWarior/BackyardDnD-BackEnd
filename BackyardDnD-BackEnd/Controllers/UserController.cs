using System;
using BackyardDnD_BackEnd.Models;
using BackyardDnD_BackEnd.Models.character;
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
        [Route("CreateCharacter")]
        public bool CreateCharacter([FromBody] User user)
        {
            try
            {
                _createUserInterface.CreateCharacter(user);
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
        
        [HttpPost]
        [Route("CheckUnique")]
        public bool CheckUnique([FromBody] User user)
        {
            var bUnique = _createUserInterface.CheckUnique(user.UserName);

            return bUnique;
        }
        
        [HttpPost]
        [Route("LoadCharacter")]
        public UserCharacter LoadCharacter([FromBody] User user)
        {
            UserCharacter userCharacter = _createUserInterface.LoadCharacter(user);

            return userCharacter;
        }
        
        [HttpPost]
        [Route("sendRoll")]
        public bool SendRoll([FromBody] RollModel rollModel)
        {
            try
            {
                _createUserInterface.SendRoll(rollModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}