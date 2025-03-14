using BlockBuster.Models;

namespace BlockBuster.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConsoleUtils.ListMovies(BasicFunctions.GetAllMovies());
            //ConsoleUtils.ListObjects(BasicFunctions.GetAllMovies());
            //ConsoleUtils.WriteMoviesToCsv(BasicFunctions.GetAllMovies());

            Console.Write("Enter Output Type (Console/CSV): ");
            string outputType = Console.ReadLine();

            Console.Write("Enter Function Name (GetAllMovies/GetCheckedOutMovies/GetMoviesByGenre/GetMoviesByDirector): ");
            string functionName = Console.ReadLine();

            string? parameter = null;
            if (functionName == "GetMoviesByDirector" || functionName == "GetMoviesByGenre")
            {
                Console.Write("Enter Parameter: ");
                parameter = Console.ReadLine();
            }
            IEnumerable<Movie> movies = new List<Movie>();

            switch (functionName)
            {
                case "GetAllMovies":
                    movies = BasicFunctions.GetAllMovies();
                    break;

                case "GetCheckedOutMovies":
                   
                    movies = BasicFunctions.GetCheckedOutMovies();
                    
                    break;

                case "GetMoviesByGenre":
                    if (string.IsNullOrEmpty(parameter))
                    {
                        Console.WriteLine("Error: You must provide a genre.");
                        return;
                    }
                    movies = BasicFunctions.GetMoviesbyGenre(parameter);
                    break;

                case "GetMoviesByDirector":
                    if (string.IsNullOrEmpty(parameter))
                    {
                        Console.WriteLine("Error: You must provide a last name for a director.");
                        return;
                    }
                    movies = BasicFunctions.GetMoviesbyDirector(parameter);
                    break;

                default:
                    Console.WriteLine($"Error: Unknown function '{functionName}'");
                    return;
            }

            if (outputType == "CSV")
            {
                ConsoleUtils.WriteMoviesToCsv(movies);
            }
            else if (outputType == "Console")
            {
                ConsoleUtils.ListMovies(movies);
            }
            else
            {
                Console.WriteLine("Error: Invalid output type. Use 'CSV' or 'Console'.");
            }


        }
    }
}
