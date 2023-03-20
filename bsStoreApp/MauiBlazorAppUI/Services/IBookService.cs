using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorAppUI.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
    }
}
