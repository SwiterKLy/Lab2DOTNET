namespace WebApplication1.Entities
{
    public class Book
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Lable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }

        public string BookGenre { get; set; }
        public string BookPublisher { get; set; }
    }
}
