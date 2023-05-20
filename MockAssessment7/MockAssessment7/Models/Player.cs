using MockAssessment7.Models;

namespace MockAssessment7.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Level { get; set; }
        public int CurrentClassId { get; set; }

        public Player(int id, string username, int level, int currentclassid)
        {
            Id = id;
            UserName = username;
            Level = level;
            CurrentClassId = currentclassid;
        }

        public static List<Player> Players = new List<Player>
        {
            new Player(0, "GrantChirpus", 100, 1),
            new Player(1, "Gamer", 50, 0),
            new Player(2, "Green-Bean-Gaming", 75, 2),
            new Player(3, "Jeffrey", 80, 0),
            new Player(4, "FunnyFrog2", 90, 3),
        };
    }
}

