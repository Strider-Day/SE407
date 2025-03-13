using BookStore.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleApp
{
    public class ConsoleUtils
    {
        public static void ListBooks(IEnumerable<Book> books)
        {
            System.Console.WriteLine("List of Books");

            foreach (Book b in books)
            {
                System.Console.WriteLine($"Book Title: {b.BookTitle}, Genre: {b.Genre?.GenreType ?? "N/A"}, Author: {b.Author?.AuthorFirst} {b.Author?.AuthorLast}, Release Year: {b.YearOfRelease}");

            }
        }

        public static void WriteBooksToCsv(IEnumerable<Book> books)
        {
            using (StreamWriter streamWriter = new StreamWriter("..\\Books.csv"))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(books);
                }
            }
        }
    }
}
