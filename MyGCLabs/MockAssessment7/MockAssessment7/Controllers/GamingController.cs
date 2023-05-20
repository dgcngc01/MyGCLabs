using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MockAssessment7.Models;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockAssessment7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingController : ControllerBase
    {
        // GET: api/<GamingController>

        [HttpGet("All Players")]
        public ActionResult<List<Player>> GetPlayers()
        {
            try
            {
                return Ok(Player.Players);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/<GamingController>

        [HttpGet("All Player Classes")]
        public ActionResult<List<Player>> GetPlayerClasses()
        {
            try
            {
                return Ok(PlayerClass.PlayerClasses);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("PlayerMinLevel")]
        public ActionResult<List<Player>> GetPlayerMinLevel(int minLevel)
        {
            var result = Player.Players.FindAll(player => player.Level < minLevel);

            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet("PlayerSortLevel")]
        public ActionResult<List<Player>> GetPlayerSortByLevel()
        {

            try
            {
                return Ok(Player.Players.OrderBy(o => o.Level).ToList());

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("PlayersOfClass")]
        public List<Player> GetPlayersOfClass(string searchQuery)
        {
            List<Player> result = new List<Player>();

            // find the ID that corresponds with the searchQuery

            // 1 way
            //int classId = PlayerClass.PlayerClasses.Find(pc => pc.Name == searchQuery).Id;

            // or 
            PlayerClass playerClassResult = PlayerClass.PlayerClasses.Find(pc => pc.Name == searchQuery);
            int classId = playerClassResult.Id;

            // loop though all the players and find players with that ID

            foreach (Player player in Player.Players)
            { 
                if(player.CurrentClassId == classId)
                { 
                    result.Add(player);                
                }            
            }
            return result;

        }

        // #7 don't have 6

        [HttpGet("AllPlayerClasses")]
        public List<PlayerClass> GettingUniqueCurrentClasses()
        {
            // declaring the object to return first
            List <PlayerClass> result = new List<PlayerClass>();

            // Creating a list of all IDs useed by players (contains duplicates)
            List<int> playerClassIds = Player.Players.Select(p => p.CurrentClassId).ToList();

            // reduce to unique ids
            List<int> uniqueClassIds = playerClassIds.Distinct().ToList();


            // find each player with unique id
            foreach (int uniqueId in uniqueClassIds)
            {
                result.Add(PlayerClass.PlayerClasses.Find(PlayerClass => PlayerClass.Id == uniqueId));
            }

            return result;

        }
    }
}


// Insturctors answers`
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MockAssessment7.Models;

//namespace MockAssessment7.Controllers
//{
//    // url: localhost.com/api/gaming

//    [Route("api/[controller]")]
//    [ApiController]
//    public class GamingController : ControllerBase
//    {
//        GameDB DB = new GameDB();

//        // 1.  Players - an endpoint that returns all players. - 1pt
//        //               Return back all Players as a list

//        [HttpGet("Players")]
//        public List<Player> GetPlayers()
//        {
//            return DB.Players;
//        }

//        // 2. Classes - an endpoint that returns all PlayerClasses.  - 1pt
//        //          Return back all PlayerClasses as a list

//        [HttpGet("Classes")]
//        public List<PlayerClass> GetPlayerClasses()
//        {
//            return DB.PlayerClasses;
//        }

//        /*
//         * 5. PlayersOfClass- this endpoint will take in a string and search for all Players with that PlayerClass name 
//         * - 2 pt (1 for working endpoint and return. 1 for correct info being return)
//         * 
//         */

//        [HttpGet("PlayersOfClass")]
//        public List<Player> GetPlayersOfClass(string searchQuery)
//        {
//            List<Player> result = new List<Player>();

//            // find the PlayerClass ID that corresponds with the 'searchQuery'

//            PlayerClass playerClassResult = DB.PlayerClasses.Find(pc => pc.Name == searchQuery);

//            int classID = playerClassResult.ID;

//            // loop through all players and find players with that ID

//            // result = DB.Players.Where(p => p.PlayerClassId == classID).ToList();

//            foreach (Player player in DB.Players)
//            {
//                if (player.PlayerClassId == classID)
//                {
//                    result.Add(player);
//                }
//            }

//            return result;
//        }

//        /*
//         * 
//         * AllPlayedClasses - this endpoint will filter through the Players and return 
//         *                    all CurrentClasses (PlayerClass) being used. 
//         *                    
//         *                    A. The returned list should not return duplicates ( Distinct() is your friend! )
//         *                    B. The returned list should not contain Thief
//         *                    
//         *                    - 2 pt (1 for working endpoint and return. 1 for correct info being returned)
//        */

//        /*
//        [HttpGet("AllPlayedClasses")]
//        public List<PlayerClass> GetUniqueCurrentClasses()
//        {
//            // Declaring the object to return first

//            List<PlayerClass> result = new List<PlayerClass>();

//            // Creating a list of all IDs used by players (contains duplicates)

//            List<int> playerClassIds = DB.Players.Select(p => p.PlayerClassId).ToList();

//            // Reduce down to unique/distinct IDs

//            List<int> uniqueClassIds = playerClassIds.Distinct().ToList();

//            // Find each PlayerClass with the unique IDs

//            foreach (int uniqueId in uniqueClassIds)
//            {
//                result.Add(DB.PlayerClasses.Find(pc => pc.ID == uniqueId));
//            }

//            return result;
//        }
//        */

//        [HttpGet("GetAllPlayedClasses")]
//        public List<PlayerClass> GetAllPlayedClasses()
//        {
//            List<PlayerClass> output = new List<PlayerClass>();

//            foreach (Player p in DB.Players)
//            {
//                PlayerClass pc = DB.PlayerClasses.Where(c => c.ID == p.PlayerClassId).First();

//                if (!output.Contains(pc))
//                {
//                    output.Add(pc);
//                }
//            }

//            return output;
//        }
//    }
//}