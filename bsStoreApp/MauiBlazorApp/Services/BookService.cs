using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
 
 

namespace MauiBlazorApp.Services
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
