
# GraphQLTest

### GraphQLServer ###
GraphQL Server with Hotchocolate & .Net.

## Usage/Examples for GraphQL in .net
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

## Usage example online
### Get Autores
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

### Create Autor
            mutation addAutor($inputAutor: AutorInputTypeInput!){
              createAutor(inputAutor:  $inputAutor ) {
                id
               nombre
               apellidos
               email
               salario 
              }
            }

### Delete Autor
            mutation addAutor($inputAutor: AutorInputTypeInput!){
              createAutor(inputAutor:  $inputAutor ) {
                id
               nombre
               apellidos
               email
               salario 
              }
            }

In the section "Variables", you need to add them, like this.

            {
              "inputAutor": {
                "apellidos": "lastname",
                "email": "example@example.com",
                "nombre": "firstname",
                "salario": 1000
              }  
            }

The API is available at: "https://booktestapi.application-service.work/graphql/".

![App Screenshot](https://res.cloudinary.com/imgresd/image/upload/v1695431017/Github/exampleBanana_sgkszv.png)
## Running Tests

To run tests, run GraphQLServerTests.cs from project GraphQLServer.NUnitTest

![App Screenshot](https://res.cloudinary.com/imgresd/image/upload/v1695431146/Github/testsGraphql_amolkl.png)


## Feedback

If you have any feedback, please reach out to me.

