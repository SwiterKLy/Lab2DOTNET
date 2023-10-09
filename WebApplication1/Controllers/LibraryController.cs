using Dapper;
using WebApplication1.Dto;
using WebApplication1.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1.Contracts;

namespace WebApplication1.Controllers
{
        [ApiController]
        [Route("/api/[controller]")]
        public class LibraryController : ControllerBase
        {
            private readonly ILibraryRepository _libraryRepo;

            public LibraryController(ILibraryRepository libraryRepo)
            {
                _libraryRepo = libraryRepo;
            }

            // Методы для работы с таблицей Book

            [HttpGet("GetBooks")]
            public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
            {
                try
                {
                    var books = await _libraryRepo.GetBooks();
                    return Ok(books);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpGet("GetBook/{id}", Name = "BookById")]
            public async Task<IActionResult> GetBook(int id)
            {
                try
                {
                    var book = await _libraryRepo.GetBook(id);
                    if (book == null)
                        return NotFound();

                    return Ok(book);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPost("CreateBook")]
            public async Task<IActionResult> CreateBook(BookForCreationDto book)
            {
                try
                {
                    var createdBook = await _libraryRepo.CreateBook(book);
                    return CreatedAtRoute("BookById", new { id = createdBook.Code }, createdBook);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPut("UpdateBook/{id}")]
            public async Task<IActionResult> UpdateBook(int id, BookForUpdateDto book)
            {
                try
                {
                    var dbBook = await _libraryRepo.GetBook(id);
                    if (dbBook == null)
                        return NotFound();

                    await _libraryRepo.UpdateBook(id, book);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpDelete("DeleteBook/{id}")]
            public async Task<IActionResult> DeleteBook(int id)
            {
                try
                {
                    var dbBook = await _libraryRepo.GetBook(id);
                    if (dbBook == null)
                        return NotFound();

                    await _libraryRepo.DeleteBook(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            // Методы для работы с таблицей BookReservation

            [HttpGet("GetBookReservations")]
            public async Task<ActionResult<IEnumerable<BookReservation>>> GetBookReservations()
            {
                try
                {
                    var reservations = await _libraryRepo.GetBookReservations();
                    return Ok(reservations);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpGet("GetBookReservation/{id}", Name = "BookReservationById")]
            public async Task<IActionResult> GetBookReservation(int id)
            {
                try
                {
                    var reservation = await _libraryRepo.GetBookReservation(id);
                    if (reservation == null)
                        return NotFound();

                    return Ok(reservation);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPost("CreateBookReservation")]
            public async Task<IActionResult> CreateBookReservation(BookReservationForCreationDto bookReservation)
            {
                try
                {
                    var createdReservation = await _libraryRepo.CreateBookReservation(bookReservation);
                    return CreatedAtRoute("BookReservationById", new { id = createdReservation.Code }, createdReservation);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPut("UpdateBookReservation/{id}")]
            public async Task<IActionResult> UpdateBookReservation(int id, BookReservationForUpdateDto bookReservation)
            {
                try
                {
                    var dbReservation = await _libraryRepo.GetBookReservation(id);
                    if (dbReservation == null)
                        return NotFound();

                    await _libraryRepo.UpdateBookReservation(id, bookReservation);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpDelete("DeleteBookReservation/{id}")]
            public async Task<IActionResult> DeleteBookReservation(int id)
            {
                try
                {
                    var dbReservation = await _libraryRepo.GetBookReservation(id);
                    if (dbReservation == null)
                        return NotFound();

                    await _libraryRepo.DeleteBookReservation(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            // Методы для работы с таблицей Person

            [HttpGet("GetPeople")]
            public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
            {
                try
                {
                    var people = await _libraryRepo.GetPeople();
                    return Ok(people);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpGet("GetPerson/{id}", Name = "PersonById")]
            public async Task<IActionResult> GetPerson(int id)
            {
                try
                {
                    var person = await _libraryRepo.GetPerson(id);
                    if (person == null)
                        return NotFound();

                    return Ok(person);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPost("CreatePerson")]
            public async Task<IActionResult> CreatePerson(PersonForCreationDto person)
            {
                try
                {
                    var createdPerson = await _libraryRepo.CreatePerson(person);
                    return CreatedAtRoute("PersonById", new { id = createdPerson.TicketCode }, createdPerson);
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPut("UpdatePerson/{id}")]
            public async Task<IActionResult> UpdatePerson(int id, PersonForUpdateDto person)
            {
                try
                {
                    var dbPerson = await _libraryRepo.GetPerson(id);
                    if (dbPerson == null)
                        return NotFound();

                    await _libraryRepo.UpdatePerson(id, person);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpDelete("DeletePerson/{id}")]
            public async Task<IActionResult> DeletePerson(int id)
            {
                try
                {
                    var dbPerson = await _libraryRepo.GetPerson(id);
                    if (dbPerson == null)
                        return NotFound();

                    await _libraryRepo.DeletePerson(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    // Логируйте ошибку
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }






