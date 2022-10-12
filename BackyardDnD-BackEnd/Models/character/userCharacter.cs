namespace BackyardDnD_BackEnd.Models.character
{
    public class UserCharacter
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public string ClassName { get; set; }
        public int Age { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public int Experience { get; set; }
        public string[] PersonalityTraits { get; set; }
        public string[] Flaws { get; set; }
        public string[] Ideals { get; set; }
        public string Description { get; set; }
        public string[] Family { get; set; }
        public string[] Friends { get; set; }
        public string ImagePath { get; set; }
        public int[] Strength { get; set; }
        public int[] Dexterity { get; set; }
        public int[] Constitution { get; set; }
        public int[] Intelligence { get; set; }
        public int[] Wisdom { get; set; }
        public int[] Charisma { get; set; }
    }
}