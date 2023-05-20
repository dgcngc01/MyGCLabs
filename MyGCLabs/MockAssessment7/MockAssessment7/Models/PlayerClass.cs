namespace MockAssessment7.Models
{
    public class PlayerClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public PlayerClass(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;           
        }

        public static List<PlayerClass> PlayerClasses = new List<PlayerClass>
        {
            new PlayerClass(0, "Archer", "Damage"),
            new PlayerClass(1, "Healer", "Support"),
            new PlayerClass(2, "Knight", "Tank"),
            new PlayerClass(3, "Wizard", "Damage"),
            new PlayerClass(4, "Theif", "Damage"),
        };
    }
}
