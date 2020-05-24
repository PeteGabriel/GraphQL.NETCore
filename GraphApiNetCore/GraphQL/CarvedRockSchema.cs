using GraphApiNetCore.GraphQL.queries;
using GraphApiNetCore.GraphQL.types.inputs;
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
            //Mutation = resolver.Resolve<ProductReviewMutation>();
            Mutation = resolver.Resolve<ProductMutation>();

            
        }
    }
}