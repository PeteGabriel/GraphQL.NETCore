using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using GraphApiNetCore.Repository.impl;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types
{
    public class ProductGraphType: ObjectGraphType<Product>
    {

        public ProductGraphType(IRepository<ProductReview> prodReviewRepo,
            IDataLoaderContextAccessor dataLoaderContext)
        {
            var reviews = prodReviewRepo as ProductReviewRepository;
            
            Field(t => t.Id).Description("Id of product");
            Field(t => t.Name).Description("Name of product");
            Field(t => t.Price).Description("Price of product");
            Field(t => t.Rating).Description("Rating");
            Field(t => t.Stock).Description("Stock");
            Field(t => t.IntroducedAt).Description("When was first created");
            Field(t => t.PhotoFileName).Description("Photo file name");;
            Field<TypeGraphType>(Name= "Type", Description="Type of product");

            Field<ListGraphType<ProductReviewGraphType>>(
                "review", 
                "Reviews related to this product",
                resolve: ctx =>
                {
                    if (reviews == null) return new ProductReviewGraphType[] { };
                    
                    var loader = dataLoaderContext.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                        "GetReviewsByProductId", reviews.FetchByProducts);
                    return loader.LoadAsync(ctx.Source.Id);
                });

        }

    }
}