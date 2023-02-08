// Doug Coffey
// Movie Database Lab

using MoviesDatabase;
bool isDone = false;
string userWantsToContinue = "";
string userCategory = "";
int integerEntered = 0;
bool isInt = false;

MyMethods.GreetPerson();

MyMovies myMovie1 = new MyMovies();
myMovie1.Name = "Blade Runner";
myMovie1.Category = "scifi";

MyMovies myMovie2 = new MyMovies();
myMovie2.Name = "Alien";
myMovie2.Category = "scifi";

MyMovies myMovie3 = new MyMovies();
myMovie3.Name = "The Matrix";
myMovie3.Category = "scifi";

MyMovies myMovie4 = new MyMovies();
myMovie4.Name = "Nightmare on Elm Street";
myMovie4.Category = "horror";

MyMovies myMovie5 = new MyMovies();
myMovie5.Name = "Halloween";
myMovie5.Category = "horror";

MyMovies myMovie6 = new MyMovies();
myMovie6.Name = "Friday the 13th";
myMovie6.Category = "horror";

MyMovies myMovie7 = new MyMovies();
myMovie7.Name = "SpongeBob";
myMovie7.Category = "animated";

MyMovies myMovie8 = new MyMovies();
myMovie8.Name = "Frosty The Snowman";
myMovie8.Category = "animated";

MyMovies myMovie9 = new MyMovies();
myMovie9.Name = "Minions";
myMovie9.Category = "animated";

MyMovies myMovie10 = new MyMovies();
myMovie10.Name = "Hustle";
myMovie10.Category = "drama";

MyMovies myMovie11 = new MyMovies(); ;
myMovie11.Name = "Babaloyn";
myMovie11.Category = "drama";

MyMovies myMovie12 = new MyMovies();
myMovie12.Name = "The Woman King";
myMovie12.Category = "drama";

Dictionary<string, string> numToCategory = new Dictionary<string, string>();
numToCategory["1"] = "animated";
numToCategory.Add("2", "drama");
numToCategory.Add("3", "horror");
numToCategory.Add("4", "scifi");

List<MyMovies> movieList = new List<MyMovies>()
{
    myMovie1,
    myMovie2,
    myMovie3,
    myMovie4,
    myMovie5,
    myMovie6,
    myMovie7,
    myMovie8,
    myMovie9,
    myMovie10,
    myMovie11,
    myMovie12,
};

while (!isDone)
{
    MyMethods.MovieCategories();
    while (!isInt)
    {       
        userCategory = Console.ReadLine().ToLower();

        isInt = int.TryParse(userCategory, out integerEntered);

        if (isInt && integerEntered >= 1 && integerEntered <= 4)
        {
            string userCategoryName = numToCategory[userCategory];

            Console.WriteLine($"\nThese are the movies we have for the category {userCategoryName.ToUpper()}:");

            foreach (var eachMovie in movieList.OrderBy(a => a.Category).ThenBy(a => a.Name))
            {
                if (eachMovie.Category == userCategoryName) 
                    Console.WriteLine(eachMovie.Name);
            }
        }
        else
        {
            Console.WriteLine($"You did not enter a number!!!!\n");
        }
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
                Console.WriteLine($"\nHave a great day. Please come back soon.\n");
            }
            else if (userWantsToContinue == "y")
            {
                isDone = false;
                isInt = false;  
            }
        }
    }
}