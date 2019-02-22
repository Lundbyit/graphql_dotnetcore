using GraphQL.DataLoader;
using GraphQL.Types;
using graphql_dotnetcore.Data.Entities;
using graphql_dotnetcore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(BookRepository bookRepo, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("Name of author");
            Field<GenreEnumType>("Genre", "Genre of author");

            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Book>(
                            "GetBookByAuthorId", bookRepo.GetBooksForAuthors);
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}
