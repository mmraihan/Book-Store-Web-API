using BookStore.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
    }
}
