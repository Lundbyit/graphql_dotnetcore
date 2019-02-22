using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.GraphQL
{
    public class BookStoreSchema : Schema
    {
        public BookStoreSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BookStoreQuery>();
            Mutation = resolver.Resolve<BookStoreMutation>();
        }
    }
}
