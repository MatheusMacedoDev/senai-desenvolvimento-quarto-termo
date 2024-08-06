using Moq;
using ProductsManagementForUnitTest.Domains;
using ProductsManagementForUnitTest.Interfaces;
using ProductsManagementForUnitTest.Repositories;
using System.Security.Cryptography.Xml;

namespace TestProject
{
    public class ProductManagementTest
    {
        /// <summary>
        /// Teste para a funcionalidade de listar todos os produtos
        /// </summary>
        [Fact]
        public async void GetAll()
        {
            // Arrange
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.GetProducts()).ReturnsAsync(products);

            // Act
            var result = await mockRepository.Object.GetProducts();

            // Assert
            Assert.Equal(3, products.Count);
        }

        /// <summary>
        /// Teste para a funcionalidade de criar produtos
        /// </summary>
        [Fact]
        public async void CreateProductTest()
        {
            // Arrange
            var product = new Product()
            {
                ProductId = Guid.NewGuid(),
                Name = "Produto 1",
                Price = 10
            };

            var products = new List<Product>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.CreateProduct(product)).Callback<Product>(x => products.Add(product));

            // Act
            mockRepository.Object.CreateProduct(product);

            // Assert
            Assert.Contains(product, products);

        }

        /// <summary>
        /// Teste para a funcionalidade de buscar um produto por id
        /// </summary>
        [Fact]
        public async void GetById()
        {
            // Arrange
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.GetProductById(products[0].ProductId)).ReturnsAsync(products[0]);

            // Act
            var result = await mockRepository.Object.GetProductById(products[0].ProductId);

            // Assert
            Assert.Equal("Cell Phone", result.Name);
        }

        /// <summary>
        /// Teste para a funcionalidade de remover um produto
        /// </summary>
        [Fact]
        public async void DeleteProductTest()
        {
            // Arrange
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.DeleteProduct(products[0].ProductId)).Callback(() => products.Remove(products[0]));

            // Act
            await mockRepository.Object.DeleteProduct(products[0].ProductId);

            // Assert
            Assert.DoesNotContain(products, product => product.Name == "Cell Phone");
        }

        /// <summary>
        /// Teste para a funcionalidade de atualizar os dados de um produto um produto
        /// </summary>
        [Fact]
        public async void UpdateProductTest()
        {
            // Arrange
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var newProductData = new Product()
            {
                ProductId = products[0].ProductId,
                Name = "Call me on my cell phone",
                Price = 10.45m
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.UpdateProduct(newProductData)).Callback(() =>
            {
                products[0].Name = "Call me on my cell phone";
                products[0].Price = 10.45m;
            });

            // Act
            await mockRepository.Object.UpdateProduct(newProductData);

            // Assert
            Assert.Contains(products, product => product.Name == "Call me on my cell phone");

        }
    }
}