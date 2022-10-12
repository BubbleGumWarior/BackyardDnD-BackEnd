using System;
using System.Data;
using BackyardDnD_BackEnd.Models;
using BackyardDnD_BackEnd.Models.character;

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
        public UserCharacter ConvertCharModel(DataTable dtUser)
        {
            var userCharacter = new UserCharacter();
            foreach (DataRow itemRow in dtUser.Rows)
            {
                userCharacter.UserName = itemRow["userName"].ToString();
                userCharacter.Name = itemRow["name"].ToString();
                userCharacter.Race = itemRow["race"].ToString();
                userCharacter.Alignment = itemRow["alignment"].ToString();
                userCharacter.ClassName = itemRow["className"].ToString();
                userCharacter.Age = (int) Convert.ToInt32(itemRow["age"]);
                userCharacter.CurrentHealth = (int) Convert.ToInt32(itemRow["currentHealth"]);
                userCharacter.MaxHealth = (int) Convert.ToInt32(itemRow["maxHealth"]);
                userCharacter.CurrentMana = (int) Convert.ToInt32(itemRow["currentMana"]);
                userCharacter.MaxMana = (int) Convert.ToInt32(itemRow["maxMana"]);
                userCharacter.Experience = (int) Convert.ToInt32(itemRow["experience"]);
                userCharacter.PersonalityTraits = itemRow["personalityTraits"].ToString()?.Split(',');
                userCharacter.Flaws = itemRow["flaws"].ToString()?.Split(',');
                userCharacter.Ideals = itemRow["ideals"].ToString()?.Split(',');
                userCharacter.Description = itemRow["description"].ToString();
                userCharacter.Family = itemRow["family"].ToString()?.Split(',');
                userCharacter.Friends = itemRow["friends"].ToString()?.Split(',');
                userCharacter.ImagePath = itemRow["imagePath"].ToString();
                userCharacter.Strength = Array.ConvertAll(itemRow["strength"].ToString()?.Split(',') ?? throw new InvalidOperationException(), int.Parse);
                userCharacter.Dexterity = Array.ConvertAll(itemRow["dexterity"].ToString()?.Split(',') ?? throw new InvalidOperationException(), int.Parse);
                userCharacter.Constitution = Array.ConvertAll(itemRow["constitution"].ToString()?.Split(',') ?? throw new InvalidOperationException(), int.Parse);
                userCharacter.Intelligence = Array.ConvertAll(itemRow["intelligence"].ToString()?.Split(',') ?? throw new InvalidOperationException(), int.Parse);
                userCharacter.Wisdom = Array.ConvertAll(itemRow["wisdom"].ToString()?.Split(',') ?? throw new InvalidOperationException(), int.Parse);
                userCharacter.Charisma = Array.ConvertAll(itemRow["charisma"].ToString()?.Split(',') ?? throw new InvalidOperationException(), int.Parse);
            }
            Console.WriteLine(userCharacter.UserName);

            return userCharacter;
        }
    }
}