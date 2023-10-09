using WebApplication1.Dto;
using WebApplication1.Entities;

namespace WebApplication1.Contracts
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> CreateBook(BookForCreationDto book);
        Task UpdateBook(int id, BookForUpdateDto book);
        Task DeleteBook(int id);

        Task<IEnumerable<BookReservation>> GetBookReservations();
        Task<BookReservation> GetBookReservation(int id);
        Task<BookReservation> CreateBookReservation(BookReservationForCreationDto bookReservation);
        Task UpdateBookReservation(int id, BookReservationForUpdateDto bookReservation);
        Task DeleteBookReservation(int id);

        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(int id);
        Task<Person> CreatePerson(PersonForCreationDto person);
        Task UpdatePerson(int id, PersonForUpdateDto person);
        Task DeletePerson(int id);
    }
}
