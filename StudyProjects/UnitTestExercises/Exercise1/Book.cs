namespace Exercise1
{
    public class Book
    {
        public string Title { get; private set; }
        public short ReleaseYear { get; private set; }

        public Book(string title, short realeaseYear)
        {
            Title = title;
            ReleaseYear = realeaseYear;
        }
    }
}
