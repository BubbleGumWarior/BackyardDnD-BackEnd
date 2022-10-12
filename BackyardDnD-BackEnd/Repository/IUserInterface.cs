using System.Security.Claims;
using BackyardDnD_BackEnd.Models;
using BackyardDnD_BackEnd.Models.character;

namespace BackyardDnD_BackEnd.Repository
{
    public interface IUserInterface
    {
        public string RegisterUser(User user);
        public bool LoginUser(string username, string password);
        bool CheckUnique(string userName);
        string CreateCharacter(User user);
        UserCharacter LoadCharacter(User user);
    }
}