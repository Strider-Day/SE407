using BookStore.Models;

namespace BookStore.Test
{
    public class BasicFunctionsTest
    {
        [Fact]
        public void TestGetBookByTitle()
        {
            Book? testbook = BookStoreBasicFunctions.GetBookByTitle("Test Book");
            Assert.Equal(3172, testbook?.BookId);
        }

        [Fact]
        public void TestGetAllBooks()
        {
            int count = BookStoreBasicFunctions.GetAllBooks().Count();
            Assert.Equal(3, count);
        }
        [Fact]
        public void TestGetBooksByAuthor()
        {
            List<Book> testbook = BookStoreBasicFunctions.GetBooksbyAuthor("Chaucers");
            Assert.NotEmpty(testbook);
        }
    }
}