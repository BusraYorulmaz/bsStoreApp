using Entities.Models;

namespace BlazorApp1.Services
{
    public class BookService :IBookService
    {
        private readonly HttpClient httpClient;

        public BookService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await httpClient.GetFromJsonAsync<List<Book>>("api/books/GetAllBooks");
        }
    }
}
