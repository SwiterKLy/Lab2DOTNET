namespace WebApplication1.Entities
{
    public class Person
    {
        public int TicketCode { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string ContactPhone { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<BookReservation> BookReservations { get; set; } = new List<BookReservation>();
    }
}
