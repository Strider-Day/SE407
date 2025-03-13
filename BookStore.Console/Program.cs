using BookStore.Models;

namespace BookStore.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConsoleUtils.ListBooks(BookStoreBasicFunctions.GetAllBooks());
            //ConsoleUtils.WriteBooksToCsv(BookStoreBasicFunctions.GetAllBooks());

            Console.Write("Enter Output Type (Console/CSV): ");
            string outputType = Console.ReadLine();

            Console.Write("Enter Function Name (GetAllBooks/GetBookByTitle/GetBooksByAuthor): ");
            string functionName = Console.ReadLine();

            string? parameter = null;
            if (functionName == "GetBookByTitle" || functionName == "GetBooksByAuthor")
            {
                Console.Write("Enter Parameter: ");
                parameter = Console.ReadLine();
            }
            IEnumerable<Book> books = new List<Book>();
            //Book onebook = new Book();

            switch (functionName)
            {
                case "GetAllBooks":
                    books = BookStoreBasicFunctions.GetAllBooks(); break;
                case "GetBooksByTitle":
                    if (string.IsNullOrEmpty(parameter))
                    {
                        Console.WriteLine("Error: You must provide a title.");
                        return;
                    }
                    Book? onebook = BookStoreBasicFunctions.GetBookByTitle(parameter);
                    books = onebook != null ? new List<Book> { onebook } : new List<Book>();
                    break;
                case "GetBooksByAuthor":
                    if (string.IsNullOrEmpty(parameter))
                    {
                        Console.WriteLine("Error: You must provide a last name.");
                        return;
                    }
                    books = BookStoreBasicFunctions.GetBooksbyAuthor(parameter); break;
                default:
                    Console.WriteLine($"Error: Unknown function '{functionName}'");
                    return;
            }
            if (outputType == "CSV")
            {
                ConsoleUtils.WriteBooksToCsv(books);
            }
            else if (outputType == "Console")
            {
                ConsoleUtils.ListBooks(books);
            }
            else
            {
                Console.WriteLine("Error: Invalid output type. Use 'CSV' or 'Console'.");
            }
        }
    }
}
