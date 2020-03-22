using GraphApiNetCore.GraphQL.queries;
using GraphApiNetCore.Repository.entities;
using GraphQL;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL
{
    public class CarvedRockSchema : Schema
    {
        public CarvedRockSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<ProductQuery>();
        }
    }
}