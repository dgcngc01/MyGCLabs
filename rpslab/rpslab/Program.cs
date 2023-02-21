//Doug Coffey
// Roshambo lab

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static rpslab.Enums;
using static rpslab.Program;

namespace rpslab
{
    class Program
    {
        public abstract class Player  // Base class (parent) Abstract classes cannot be instantiated. They MUST be inherited.
        {
            public string GetPlayerName()
            {
                string Name = "Dwayne Johnson";
                return Name;
            }

            public string GetStaticWeapon()
            {
                string RoshamboValue = "rock";
                return RoshamboValue;
            }

            public string GetRandpomPlayerName()
            {
                string RandomPlayerName = "Jonsey";
                return RandomPlayerName;
            }

            public string GenerateRoshambo()
            {
                Array values = Enum.GetValues(typeof(Enums.Roshambo));
                Random random = new Random();
                Roshambo randomValue = (Roshambo)values.GetValue(random.Next(values.Length));
                return randomValue.ToString();
            }
        }

        public class RandomPlayer : Player
        {
            public string GetRandomPlayerName()
            {
                // although no code is technically needed, I did this here to prove it
                // could be called in either place see Random Player access vs this one.
                RockPlayer newRandomPlayerName = new RockPlayer();
                string newRandomName = newRandomPlayerName.GetRandpomPlayerName();
                return newRandomName;
            }
        }

        public class RockPlayer : Player
        {
            public string GetRockPlayerWeapon()
            {
                // although no code is technically needed, I did this here to prove it
                // could be called in either place see Random Player access vs this one.
                RockPlayer newRockPlayerWeapon = new RockPlayer();
                string newWeapon = newRockPlayerWeapon.GetStaticWeapon();
                return newWeapon;
            }
        }

        public class HumanPlayer : Player
        {
            public string GetHumanName()
            {
                Console.WriteLine("Please enter your name:");
                string userName = Console.ReadLine();
                return userName;
            }
            public int GetWhoDeyPlay()
            {
                bool isInt = false;
                int integerEntered = 0;

                Console.WriteLine($"\nWould you like to play against the Jets(1) or the Sharks(2)?  Enter 1 or 2.");
                string whoToPlay = Console.ReadLine();

                while (!isInt)
                {
                    isInt = Validator.WasIntEntered(whoToPlay);

                    if (!isInt)
                    {
                        Console.WriteLine($"\nInvalid data entered.");
                        Console.WriteLine($"Would you like to play against theJets(1) or the  Sharks(2)?  Enter 1 or 2.");
                        whoToPlay = Console.ReadLine();
                        isInt = false;
                    } 
                }
                
                integerEntered = int.Parse(whoToPlay);
                return integerEntered;
            }

            public int selectYourWeapon()
            {
                bool isInt = false;
                int integerEntered = 0;

                int iCtr = 1;
                Console.WriteLine($"\nSelect your weapon by entering the appropriate number  Enter 1, 2, or 3.");
                foreach (string str in Enum.GetNames(typeof(Enums.Roshambo)))
                {
                    Console.WriteLine($"{iCtr} - {str}");
                    iCtr++;
                }
                string choiceOfWeapon = Console.ReadLine();

                while (!isInt)
                {
                    isInt = int.TryParse(choiceOfWeapon, out integerEntered);

                    if (integerEntered < 1 || integerEntered > 3)
                        isInt = false;

                    if (!isInt)
                    {
                        Console.WriteLine($"\nInvalid data entered.");
                        Console.WriteLine($"Select your weapon by entering the appropriate number  Enter 1, 2, or 3.");
                        choiceOfWeapon = Console.ReadLine();
                    }
                } 
                return integerEntered - 1;   // subtract 1 to align with enum values
            }
        }

        static void Main(string[] args)
        {
            bool keepPlaying = true;
            int playCtr = 0;
            int humanWonCtr = 0;
            int opponentWonCtr = 0;
            int drawCtr = 0;


            Console.WriteLine("Welcome to the Grand Circus rock paper sissors lab!\n");
            // create my human - name
            HumanPlayer newHumanName = new HumanPlayer();
            string playerName = newHumanName.GetHumanName();
            Console.WriteLine($"\nHello {playerName}!");

            while (keepPlaying)
            {
                playCtr++;
                // who does my human want to play
                int whoDeyPlayin = newHumanName.GetWhoDeyPlay();
                string whoWon = "";

                // human selects his weapon of choice...
                int intHumanWeapon = newHumanName.selectYourWeapon();
                string humanWeapon = Enum.GetName(typeof(Enums.Roshambo), intHumanWeapon);

                if (whoDeyPlayin == 1)  // selected to play Rock thower
                {
                    // if Rock Player is chosen get the name
                    RockPlayer newRockPlayerName = new RockPlayer();
                    string newRockName = newRockPlayerName.GetPlayerName();

                    // if Rock Player is chosen get the weapon (option 1)
                    RockPlayer newRockPlayerWeapon = new RockPlayer();
                    string newStaticWeapon = newRockPlayerWeapon.GetStaticWeapon();

                    // get name of enum selection
                    var intStaticWeapon = (int)((Enums.Roshambo)Enum.Parse(typeof(Enums.Roshambo), newStaticWeapon));
                    
                    // write results
                    Console.WriteLine($"\n{playerName} threw: {humanWeapon} \n{newRockName} of the Jets has thown: {newStaticWeapon}!");
                    whoWon = MyMethods.whoBeatsWho(intHumanWeapon, intStaticWeapon, playerName, newRockName);

                    // this could be a method, called twice
                    if (whoWon == "DRAW")
                    {
                        Console.WriteLine($"\nNo one won, it was a {whoWon}\n");
                        drawCtr++;
                    }
                    else if (whoWon == playerName)
                    {
                        Console.WriteLine($"\n{whoWon} is the winner\n");
                        humanWonCtr++;
                    }
                    else if (whoWon == newRockName)
                    {
                        Console.WriteLine($"\n{whoWon} is the winner\n");
                        opponentWonCtr++;
                    }
                    else
                        Console.WriteLine($"\nWe all lost if we got this result\n");

                }
                else if (whoDeyPlayin == 2)  // selected to play Random thower
                {
                    // if Random Player is chosen get the name (option 2)
                    RandomPlayer newRandomName = new RandomPlayer();
                    string newWeirdName = newRandomName.GetRandomPlayerName();

                    // get the name and int value of the Enum
                    RandomPlayer newRandomValue = new RandomPlayer();
                    string randomWeapon = newRandomValue.GenerateRoshambo();
                    var intRandomeWeapon = (int)((Enums.Roshambo)Enum.Parse(typeof(Enums.Roshambo), randomWeapon));

                    Console.WriteLine($"\n{playerName} you threw {humanWeapon} \n{newWeirdName} has thown {randomWeapon}!\n");
                    whoWon = MyMethods.whoBeatsWho(intHumanWeapon, intRandomeWeapon, playerName, newWeirdName);

                    if (whoWon == "DRAW")
                    {
                        Console.WriteLine($"\nNo one won, it was a {whoWon}\n");
                        drawCtr++;
                    }
                    else if (whoWon == playerName)
                    {
                        Console.WriteLine($"\n{whoWon} is the winner\n");
                        humanWonCtr++;
                    }
                    else if (whoWon == newWeirdName)
                    {
                        Console.WriteLine($"\n{whoWon} is the winner\n");
                        opponentWonCtr++;
                    }
                    else
                        Console.WriteLine($"\nWe all lost if we got this result\n");

                }

                // see if user wants to keep playin
                keepPlaying = Validator.ValidateQuit();
                if (!keepPlaying)
                {
                    Console.WriteLine($"\nYou played the game {playCtr} time(s).\n");
                    Console.WriteLine($"\n{playerName} won {humanWonCtr}.  Your opponents won {opponentWonCtr}.  There were {drawCtr} draws.\n");
                    Console.WriteLine($"\nHave a great day. Please play again soon.\n");
                }
            }
        }
    }
}