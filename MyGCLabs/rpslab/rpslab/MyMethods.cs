using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rpslab.Program;

namespace rpslab
{
    internal class MyMethods
    {
        public static string whoBeatsWho(int x, int y, string playerName, string weirdName)
        {
            //rock = 0, paper = 1, scissors = 2
            string result = "";
            if ((x == 1 & y == 0) ||
                (x == 0 & y == 2) ||
                (x == 2 & y == 1))
            {
                result = playerName;
                return result;
            }
            else if (x == y)
            {
                result = "DRAW";
                return result;
            }
            result = weirdName;
            return result;
        }
    }
}
