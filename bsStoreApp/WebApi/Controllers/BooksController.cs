using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // RepositoryContext ifadesinin new lenmesi lazım  "_context = context;" burada otomatik olarak yapılıyor. 
        //Progrm cs üzerinden register işlemini yaptık 
        //burada ise resoulve (çözme) işlemini yapıyoruz

        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _context.Books.ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _context
                .Books
                .Where(x => x.Id.Equals(id))
                .SingleOrDefault();

                if (book is null)
                    return NotFound();//404
                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book) //FromBody book un requestin body sinden geleceğini belirtir.
        {
            try
            {
                if (book is null)
                    return BadRequest();//400

                _context.Books.Add(book);
                _context.SaveChanges();
                return StatusCode(201, book);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // ex.Message -> hatanın detayları üzerinde extra bilgi verebiliriz
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                //check book? 
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

                if (entity is null)
                    return NotFound();//404

                //check id
                if (id != book.Id)
                    return BadRequest(); //400

                // daha sonra mapper ile yapılacak
                entity.Title = book.Title;
                entity.Price = book.Price;

                _context.SaveChanges();
                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context
               .Books
               .Where(b => b.Id.Equals(id))
               .SingleOrDefault();
               
                if (entity is null) return NotFound();

                _context.Books.Remove(entity);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdatedOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                //check entity
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

                if (entity is null) return NotFound();//404

                bookPatch.ApplyTo(entity);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
