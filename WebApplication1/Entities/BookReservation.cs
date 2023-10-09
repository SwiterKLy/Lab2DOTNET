using System;

namespace WebApplication1.Entities
{
    public class BookReservation
    {
        public int Code { get; set; }
        public DateTime DateIn { get; set; }
        public int BookName { get; set; }
        public int Abonent { get; set; }
        public DateTime? DateOut { get; set; }

        public Book Book { get; set; }
        public Person AbonentPerson { get; set; }
    }
}
