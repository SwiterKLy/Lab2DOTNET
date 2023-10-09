namespace WebApplication1.Dto
{
    public class BookForUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; } // Тип изменен на string
        public string Lable { get; set; } // Тип изменен на string
        public DateTime ReleaseDate { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
    }
}
