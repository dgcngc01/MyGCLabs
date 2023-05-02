namespace MovieDatabase.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }

        public Movie(int id, string category, string title)
        {
            Id = id;
            Category = category;
            Title = title;
        }

        public static List<Movie> Movies = new List<Movie>
        {
            new Movie(1, "Comedy", "Stripes"),
            new Movie(2, "Comedy", "CadyShack"),
            new Movie(3, "Comedy", "Groundhog Day"),
            new Movie(4, "Action", "Game of Thrones"),
            new Movie(5, "Action", "Shazam"),
            new Movie(6, "Action", "Die Hard"),
            new Movie(7, "Horror", "Nightmare on Elm Street"),
            new Movie(8, "Horror", "Friday the 13th"),
            new Movie(9, "Horror", "Halloween"),
        };
    }
}