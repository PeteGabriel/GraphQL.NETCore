## "Every platform that can do HTTP requests and process JSON can consume a GraphQL API."


This is a simple example of an API build with Graphql engine to show the basic concepts of it.



### How to run:

tba


### Get Data (Queries)


_Query:_

```graphql
{
  products { 
    id
    name
    price
  }
}
```

_Result:_

```json
{
  "data": {
    "products": [
      {
        "id": 1,
        "name": "Mountain Walkers",
        "price": 219.5
      },
      {
        "id": 2,
        "name": "Blue Racer",
        "price": 350
      },
      {
        "id": 3,
        "name": "Orange Demon",
        "price": 450
      }
    ]
  }
}
```


Support to find item by id:

```graphql
query($productId: ID!){
  product(id: $productId){
    name
    price
  }
}
```

```json
{
  "data": {
    "product": {
        "id": 1,
        "name": "Mountain Walkers",
        "price": 219.5
      }
  }
}
```


### Overview of types:

---

![types](https://i.postimg.cc/Px9hCDf6/Untitled-Diagram-vpd-2.png)

tbc

### Data Loader implementation:

---

Let's imagine a query that wants all products and their reviews.

The app fetchs all the products. Now, for each product the app fetchs their review (using the product ID). This process will create an amount of queries to the database equal to _2 times the amount of products_ in the database.

The DataLoader concept is basicaly an intermediary between the app and the database that caches previous results removing the need to query so many times the database for reviews. In this implementation the DL is basicaly a dictionary or more specificaly a `ILookup<int, ProductReview>>`. The type `ILookup` is a key-value storage with search features inside the .NET Core framework.

The implementation can be seen inside the class `ProductGraphType.cs` in the resolver for the field `reviews`.

![dl](https://i.postimg.cc/L6zcYdwK/Data-Loader-example.jpg)


### Mutate Data 

For a mutation such as one to create a ProductReview resource and in the end show us the id of the new resource.

```graphql
mutation ($review: productReviewInput!) {
  createReview(review: $review){
    id
  }
}
```

We could then create a new one by supplying an input such as:

```json
{
  "review": {
    "title": "My First Review!!!",
    "review": "This is the content of my First review.",
    "productId": 3
  }
}
```

The expected result would be:

```graphql
{
  "data": {
    "createReview": {
      "id": 5
    }
  }
}
```
