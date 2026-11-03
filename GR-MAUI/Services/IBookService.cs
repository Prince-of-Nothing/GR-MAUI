using GR_MAUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GR_MAUI.Services;

public interface IBookService
{
    Task<List<Book>> GetBooksAsync();
}
