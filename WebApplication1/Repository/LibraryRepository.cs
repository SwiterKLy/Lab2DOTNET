using Dapper;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net;
using WebApplication1.Context;
using WebApplication1.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Entities;
using System.Data.SqlClient;

namespace WebApplication1.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly string _connectionString;

        public LibraryRepository(string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;")
        {
            _connectionString = connectionString;
        }

        // Методы для работы с таблицей Book

        public async Task<IEnumerable<Book>> GetBooks()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Book>("SELECT * FROM Book");
            }
        }

        public async Task<Book> GetBook(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Book>("SELECT * FROM Book WHERE code = @Id", new { Id = id });
            }
        }

        public async Task<Book> CreateBook(BookForCreationDto book)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "INSERT INTO Book (_name, author, genre, lable, release_date, _count, _cost) " +
                            "VALUES (@Name, @Author, @Genre, @Lable, @ReleaseDate, @Count, @Cost);" +
                            "SELECT SCOPE_IDENTITY();";

                var result = await dbConnection.QuerySingleAsync<int>(query, book);
                return await GetBook(result);
            }
        }

        public async Task UpdateBook(int id, BookForUpdateDto book)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "UPDATE Book SET _name = @Name, author = @Author, genre = @Genre, " +
                            "lable = @Lable, release_date = @ReleaseDate, _count = @Count, _cost = @Cost " +
                            "WHERE code = @Id";
                book.Id = id;
                await dbConnection.ExecuteAsync(query, book);
            }
        }

        public async Task DeleteBook(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "DELETE FROM Book WHERE code = @Id";
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }


        public async Task<IEnumerable<BookReservation>> GetBookReservations()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<BookReservation>("SELECT * FROM book_reservation");
            }
        }

        public async Task<BookReservation> GetBookReservation(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<BookReservation>("SELECT * FROM book_reservation WHERE code = @Id", new { Id = id });
            }
        }

        public async Task<BookReservation> CreateBookReservation(BookReservationForCreationDto bookReservation)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "INSERT INTO book_reservation (date_in, book_name, abonent, date_out) " +
                            "VALUES (@DateIn, @BookName, @Abonent, @DateOut);" +
                            "SELECT SCOPE_IDENTITY();";

                var result = await dbConnection.QuerySingleAsync<int>(query, bookReservation);
                return await GetBookReservation(result);
            }
        }

        public async Task UpdateBookReservation(int id, BookReservationForUpdateDto bookReservation)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "UPDATE book_reservation SET date_in = @DateIn, book_name = @BookName, " +
                            "abonent = @Abonent, date_out = @DateOut " +
                            "WHERE code = @Id";
                bookReservation.Id = id;
                await dbConnection.ExecuteAsync(query, bookReservation);
            }
        }

        public async Task DeleteBookReservation(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "DELETE FROM book_reservation WHERE code = @Id";
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        // Методы для работы с таблицей Person

        public async Task<IEnumerable<Person>> GetPeople()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Person>("SELECT * FROM Person");
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Person WHERE ticket_code = @Id", new { Id = id });
            }
        }

        public async Task<Person> CreatePerson(PersonForCreationDto person)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "INSERT INTO Person (surname, _name, father_name, contact_phone, registration_date) " +
                            "VALUES (@Surname, @_Name, @FatherName, @ContactPhone, @RegistrationDate);" +
                            "SELECT SCOPE_IDENTITY();";

                var result = await dbConnection.QuerySingleAsync<int>(query, person);
                return await GetPerson(result);
            }
        }

        public async Task UpdatePerson(int id, PersonForUpdateDto person)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "UPDATE Person SET surname = @Surname, _name = @_Name, " +
                            "father_name = @FatherName, contact_phone = @ContactPhone, " +
                            "registration_date = @RegistrationDate " +
                            "WHERE ticket_code = @Id";
                person.Id = id;
                await dbConnection.ExecuteAsync(query, person);
            }
        }

        public async Task DeletePerson(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var query = "DELETE FROM Person WHERE ticket_code = @Id";
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }
    }


}

