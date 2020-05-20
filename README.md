A simple GraphQL api built with .NET Core.
----

Overview of types:

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


How to run:

---

Go to __/ui/playground__

Query:

```graphql
{
  products { 
    id
    name
    price
  }
}
```

Result:

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

