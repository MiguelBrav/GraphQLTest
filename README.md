
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
                    nodes {
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
                    nodes {
                        id
                        nombre
                        apellidos
                    }
                    totalCount
                }
            }

### Get Autor by Id
            query getAutorById($autorId: Int!){
                autorById(id: $autorId){
                id
                nombre    
                apellidos
                email
                salario
                publicaciones{
                  id
                  titulo
                  imagenUrl
                }
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
            mutation deleteAutor($autorId: Int!){
                      deleteAutor(autorId:  $autorId ) 
                       
                    }
                    
### Get Categorias
            query getCategorias{
              categorias {
                nodes{
                  id
                  nombre
                  publicaciones{
                    id
                    titulo
                    contenido
                  }
                },
                totalCount
              }
            }

### Get Categoria by Id
            query getCategoriabyId($categoryId: Int!){
              categoriaById(id: $categoryId) {
                id
                nombre
                publicaciones{
                  id
                  titulo
                  contenido
                  imagenUrl
      
                }
              }
            }

## Get Publicaciones
            query getPublicaciones {
              publicaciones {
                nodes{
                  id
                  titulo
                  contenido
                  imagenUrl
                  estado
                  rating
                  categoriaId
                  autorId
                }
                totalCount
              }
            }

### Get Publicacion by Id
            query getPublicacionbyId($publicationId: Int!){
            publicacionById(id: $publicationId) {
              id
              titulo
              contenido
              imagenUrl
              estado
              rating
              categoriaId
              autorId
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


## Versioning

Updated from .NET 6 to .NET 8 (22/10/25)

## Package References

All NuGet packages updated to compatible .NET 8 versions. (22/10/25)

## Feedback

If you have any feedback, please reach out to me.

