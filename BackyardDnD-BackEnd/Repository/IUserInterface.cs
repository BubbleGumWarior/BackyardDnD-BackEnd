using BackyardDnD_BackEnd.Models;

namespace BackyardDnD_BackEnd.Repository
{
    public interface IUserInterface
    {
        public string RegisterUser(User user);
        public bool LoginUser(string username, string password);
    }
}