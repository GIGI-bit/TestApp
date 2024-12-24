using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http.Json;
//using Entities.Entities;
using Entities.Entities;
//using WebApiProject;
using WebApiApp;
using System.Net;

namespace WebApiApp.Test
{
    [TestFixture]
    public class ProductTests
    {

        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services => { });
            });
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task GetProducts_ReturnsOkResponse()
        {
            var response = await _client.GetAsync("/api/product");
            response.EnsureSuccessStatusCode();
            //var products = await response.Content.ReadFromJsonAsync<List<ProductTests>>();
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task Post_AddNewProduct()
        {
            var newProd = new Product
            {
                Name = "Test Product",
                Price = 1000,
            };

            var response = await _client.PostAsJsonAsync("/api/Product", newProd);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<Product>();
            Assert.That(created != null);
            Assert.That(newProd.Name, Is.EqualTo(created.Name));

        }

        [Test]
        public async Task Put_UpdateProduct()
        {
            var randomProduct = new Product { Name = "Put Test Prduct", Price = 100 };
            var response = await _client.PutAsJsonAsync("/api/Product/1", randomProduct);
            response.EnsureSuccessStatusCode();

            var updatedResponse = await _client.GetAsync("/api/product/1");
            updatedResponse.EnsureSuccessStatusCode();
            var product = await updatedResponse.Content.ReadFromJsonAsync<Product>();

            Assert.That(product, Is.Not.Null);
            Assert.That(product.Name, Is.EqualTo("Put Test Prduct"));
            Assert.That(product.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task Get_GetProductById()
        {

            var response = await _client.GetAsync("/api/product");

            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            var product = products?.FirstOrDefault();

            if (product != null)
            {
                var responseProduct = await _client.GetAsync($"/api/product/{product.Id}");
                Assert.That(responseProduct != null);
                var p = await responseProduct.Content.ReadFromJsonAsync<Product>();
                Assert.That(p != null);
                Assert.That(p.Id, Is.EqualTo(product.Id));
            }
        }

        [Test]
        public async Task Delete_DeleteProduct()
        {
            var response = await _client.GetAsync("api/product");
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            var product = products?.FirstOrDefault();

            if (product != null)
            {
                var responseProduct = await _client.DeleteAsync($"/api/product/{product.Id}");
                Assert.That(responseProduct != null);
                Assert.That(responseProduct.StatusCode, Is.EqualTo(HttpStatusCode.NoContent), "Delete operation did not return expected status code.");

                var getDeletedResponse = await _client.GetAsync($"/api/product/{product.Id}");

                Assert.That(getDeletedResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Deleted product still exists.");

            }


        }
    }
}
