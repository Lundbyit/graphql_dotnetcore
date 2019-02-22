using GraphQL.Types;
using graphql_dotnetcore.GraphQL.Types;
using graphql_dotnetcore.Repositories;

namespace graphql_dotnetcore.GraphQL
{
    public class BookStoreQuery : ObjectGraphType
    {
        public BookStoreQuery(AuthorRepository authorRepo)
        {
            Field<ListGraphType<AuthorType>>(
                "Authors",
                resolve: context => authorRepo.GetAll()
            );

            Field<AuthorType>(
                "Author",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return authorRepo.GetOne(id);
                });
        }
    }
}
