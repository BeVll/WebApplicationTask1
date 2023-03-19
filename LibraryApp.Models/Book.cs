namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublishing { get; set; }

    }
}
internal class Program
{
    static void Main(string[] args)
    { }
}