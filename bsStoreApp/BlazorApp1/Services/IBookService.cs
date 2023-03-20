using Entities.Models;

namespace BlazorApp1.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
    }
}
