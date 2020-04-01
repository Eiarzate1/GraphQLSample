using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLSample.Types.User
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<StringGraphType>("dateOfBirth");
        }
    }
}
