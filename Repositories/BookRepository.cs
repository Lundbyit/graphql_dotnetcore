using graphql_dotnetcore.Data;
using graphql_dotnetcore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.Repositories
{
    public class BookRepository
    {
        private BookStoreDbContext _dbContext;

        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetBookForAuthor(int authorId)
        {
            return await _dbContext.Books.Where(b => b.AuthorId == authorId).ToListAsync();
        }

        public async Task<ILookup<int, Book>> GetBooksForAuthors(IEnumerable<int> authorIds)
        {
            var books = await _dbContext.Books.Where(b => authorIds.Contains(b.AuthorId)).ToListAsync();
            return books.ToLookup(b => b.AuthorId);
        }

        public async Task<Book> AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}
