namespace WebApplication1.Dto
{
    public class BookReservationForCreationDto
    {
        public int Id { get; set; }
        public DateTime DateIn { get; set; }
        public int BookName { get; set; }
        public int Abonent { get; set; }
        public DateTime? DateOut { get; set; }
    }
}
