namespace Exercise1
{
    public class BooksManager
    {
        public List<Book> Books { get; private set; }

        public BooksManager()
        {
            Books = new List<Book>();
        }

        public void AddNewBook(Book book)
        {
            Books.Add(book);
        }
    }
}
