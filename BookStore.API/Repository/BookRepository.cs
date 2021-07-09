using BookStore.API.Data;
using BookStore.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records =await  _context.Books.Select(x => new BookModel()  //Book Table in records variable,
                                                                             //convert data from to BookModel
            {
                Id =x.Id,
                Title=x.Title,
                Description=x.Description        
            }).ToListAsync();

            return records;
        }
       
    }
}
