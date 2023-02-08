using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase;

namespace MoviesDatabase
{
    internal class MyMethods
    {
        public static void GreetPerson()
        {
            Console.WriteLine("Hello, Welcome to Grand Circus' Movie Database");
            Console.WriteLine("Hope you are well.");
        }

        public static void MovieCategories()
        {

            Console.WriteLine("\nPlease enter a category number to search by:  (1 thru 4)...\n");
            Console.WriteLine("1: Animated\n" +
                              "2: Drama\n" +
                              "3: Horror\n" +
                              "4: Scifi\n" );
        }
    }
}
