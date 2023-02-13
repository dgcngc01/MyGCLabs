// Doug Coffey
// Circle Lab

using CircleLab;                             
bool isDone = false;
string userWantsToContinue = "";
string userCategory = "";
int radiusEntered = 0;
bool isInt = false;
int runCount = 1;

Circle.GreetPerson();

while (!isDone)
{
    Console.WriteLine("Enter radius: ");
    string userRadius = Console.ReadLine();

    isInt = int.TryParse(userRadius, out radiusEntered);

    if (isInt)
    {
        double circUnformatted = Circle.CalculateCircumference(radiusEntered);
        Console.WriteLine("\nCircumference is (unformatted): {0}", circUnformatted);
        string circFormatted = Circle.CalculateFormattedCircumference(radiusEntered);
        Console.WriteLine("Circumference is (unformatted): {0}", circFormatted);

        double areaUnformatted = Circle.CalculateArea(radiusEntered);
        Console.WriteLine("\nArea is (unformatted): {0}", areaUnformatted);
        string areaFormatted = Circle.CalculateFormattedArea(radiusEntered);
        Console.WriteLine("Area is (unformatted): {0}", areaFormatted);
    }
        
    if (!isDone)
    {
        userWantsToContinue = "";
        while (userWantsToContinue != "n" &&
                userWantsToContinue != "y")
        {
            Console.WriteLine($"\nWould you like to continue? ('y'/'n')\n");
            userWantsToContinue = Console.ReadLine().ToLower();

            if (userWantsToContinue == "n")
            {
                isDone = true;
                Console.WriteLine($"\nHave a great day. You created {runCount} Circle object(s).");
            }
            else if (userWantsToContinue == "y")
            {
                isDone = false;
                isInt = false;
                runCount++;
            }
        }
    }
}