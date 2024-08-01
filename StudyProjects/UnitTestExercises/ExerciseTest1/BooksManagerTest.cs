using Exercise1;

namespace ExerciseTest1
{
    public class BooksManagerTest
    {
        [Fact]
        public void AddNewBookTest()
        {
            // Arrange

            Book book = new Book(
                title: "1984",
                realeaseYear: 1949
            );

            BooksManager booksManager = new BooksManager();

            // Act
            booksManager.AddNewBook(book);

            // Assert
            foreach(var listedBook in booksManager.Books)
            {
                if (listedBook.Title != book.Title)
                    continue;

                if (listedBook.ReleaseYear != book.ReleaseYear)
                    continue;

                Assert.True(true);

                return;
            }

            Assert.Fail("This books is not into list!!");
        }
    }
}