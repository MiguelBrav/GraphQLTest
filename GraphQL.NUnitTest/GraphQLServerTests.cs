using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Text;

namespace GraphQL.NUnitTest
{
    public class GraphQLServerTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task ShouldReturnAllAutores()
        {
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
            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.That(responseContent, Does.Contain("data"));
            Assert.That(responseContent, Does.Contain("autores"));
            Assert.That(responseContent, Is.Not.Null);
        }

        [Test]
        public async Task ShouldReturnAutorById()
        {
            int autorId = 1;            

            var query = @"  
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
            ";


            var request = new
            {
                query,
                variables = new { autorId}
            };


            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("graphql", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.That(responseContent, Does.Contain("data"));
            Assert.That(responseContent, Does.Contain("Javier"));
            Assert.That(responseContent, Is.Not.Null);
        }

        [Test]
        public async Task ShouldReturnAllCategorias()
        {
            var query = @"
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
            
            ";

            var request = new
            {
                query
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("graphql", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.That(responseContent, Does.Contain("data"));
            Assert.That(responseContent, Does.Contain("categorias"));
            Assert.That(responseContent, Is.Not.Null);
        }

        [Test]
        public async Task ShouldReturnCategoriaById()
        {
            int categoryId = 2;

            var query = @"  
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
           
            ";


            var request = new
            {
                query,
                variables = new { categoryId }
            };


            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("graphql", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.That(responseContent, Does.Contain("data"));
            Assert.That(responseContent, Does.Contain("Desarrollo Web"));
            Assert.That(responseContent, Is.Not.Null);

        }

        [Test]
        public async Task ShouldReturnAllPublicaciones()
        {
            var query = @"
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
            
            ";

            var request = new
            {
                query
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("graphql", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.That(responseContent, Does.Contain("data"));
            Assert.That(responseContent, Does.Contain("publicaciones"));
            Assert.That(responseContent, Is.Not.Null);
        }

        [Test]
        public async Task ShouldReturnPublicacionById()
        {
            int publicationId = 1;

            var query = @"  
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
           
            ";


            var request = new
            {
                query,
                variables = new { publicationId }
            };


            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("graphql", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.That(responseContent, Does.Contain("data"));
            Assert.That(responseContent, Does.Contain("Mi primera"));
            Assert.That(responseContent, Is.Not.Null);
        }

    }
}