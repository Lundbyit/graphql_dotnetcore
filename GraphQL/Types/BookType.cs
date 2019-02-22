using GraphQL.Types;
using graphql_dotnetcore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}
