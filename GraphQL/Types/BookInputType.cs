using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.GraphQL.Types
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "bookInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<IntGraphType>("authorId");
            //.Description("0: Fantasy, 1: SciFi, 2: Biography");
        }
    }
}
