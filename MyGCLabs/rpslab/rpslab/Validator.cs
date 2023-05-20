using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rpslab.Program;

namespace rpslab
{
    internal class Validator
    {
        public static bool ValidateQuit()
        {
            // check and see if user wants to play again or leave program
            string userWantsToPlay = "";
            while (userWantsToPlay != "n" &&
                   userWantsToPlay != "y")
            {
                Console.WriteLine($"Play again? ('y'/'n')");
                userWantsToPlay = Console.ReadLine().ToLower();

                if (userWantsToPlay == "n")
                {
                    return false;
                }
            }
            return true;
        }

        public static bool WasIntEntered(string valueEntered)
        {
            int integerEntered = 0;
            bool wasItAnInteger = false;

            wasItAnInteger = int.TryParse(valueEntered, out integerEntered);

            if (!wasItAnInteger)
                return false;
            else if (wasItAnInteger && (integerEntered < 1 || integerEntered > 2))
                return false;

            return true;
        }
    }
}
