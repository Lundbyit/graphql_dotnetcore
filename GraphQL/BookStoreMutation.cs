using GraphQL.Types;
using graphql_dotnetcore.Data.Entities;
using graphql_dotnetcore.GraphQL.Types;
using graphql_dotnetcore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.GraphQL
{
    public class BookStoreMutation : ObjectGraphType
    {
        public BookStoreMutation(BookRepository bookRepo)
        {
            FieldAsync<BookType>(
                "createBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: async context =>
                {
                    var book = context.GetArgument<Book>("book");
                    return await context.TryAsyncResolve(
                        async c => await bookRepo.AddBook(book));
                });
        }
    }
}
