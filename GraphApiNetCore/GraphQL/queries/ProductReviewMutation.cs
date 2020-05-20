using GraphApiNetCore.GraphQL.types;
using GraphApiNetCore.GraphQL.types.inputs;
using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using GraphApiNetCore.Repository.impl;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.queries
{
    public class ProductReviewMutation : ObjectGraphType
    {

        public ProductReviewMutation(IRepository<ProductReview> repo)
        {
            FieldAsync<ProductReviewGraphType>(
                "createReview",
                "Create a review",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>>{ Name="review" }),
                resolve: async ctx =>
                { 
                    var review = ctx.GetArgument<ProductReview>("review");
                    return await ctx.TryAsyncResolve(async context => await repo.Add(review));
                }
            );
        }
    }
}