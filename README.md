A simple GraphQL api built with .NET Core.
----

How to run:


---

Go to __/ui/playground__

Query something like:

```graphql
{
  products { 
    id
    name
    price
  }
}
```

Get something like:

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
