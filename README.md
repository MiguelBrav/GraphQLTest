
# GraphQLTest

### GraphQLServer ###
GraphQL Server with Hotchocolate & .Net.

## Usage/Examples for GraphQL
You can guide from the unit tests for consuming the graphql api.

            var query = @"
              query getAutores {
                autores {
                    pageInfo {
                        hasNextPage
                        hasPreviousPage
                    }
                    items {
                        id
                        nombre
                        apellidos
                    }
                    totalCount
                }
            }
            ";

            var request = new
            {
                query
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("graphql", content);

The API is available at: "http://graphqltest.somee.com/graphql/".

![App Screenshot](https://res.cloudinary.com/imgresd/image/upload/v1695431017/Github/exampleBanana_sgkszv.png)
## Running Tests

To run tests, run GraphQLServerTests.cs from project GraphQLServer.NUnitTest

![App Screenshot](https://res.cloudinary.com/imgresd/image/upload/v1695431146/Github/testsGraphql_amolkl.png)


## Feedback

If you have any feedback, please reach out to me.

