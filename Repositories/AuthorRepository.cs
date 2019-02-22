using graphql_dotnetcore.Data;
using graphql_dotnetcore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.Repositories
{
    public class AuthorRepository
    {
        private BookStoreDbContext _dbContext;

        public AuthorRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetOne(int id)
        {
            return await _dbContext.Authors.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
