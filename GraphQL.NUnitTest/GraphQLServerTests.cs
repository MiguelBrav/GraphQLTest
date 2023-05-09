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
            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.That(responseContent, Does.Contain("data"));
            Assert.IsNotNull(responseContent);


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
            Assert.IsNotNull(responseContent);


        }

    }
}