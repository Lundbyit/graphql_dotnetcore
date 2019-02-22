using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.GraphQL.Types
{
    public class GenreEnumType : EnumerationGraphType<Data.GenreType>
    {
        public GenreEnumType()
        {
            Name = "Genre";
            Description = "Which genre it belongs to";
        }
    }
}
