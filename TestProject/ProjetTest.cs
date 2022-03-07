using Projet_Gestion_Parfumerie.Models;
using Projet_Gestion_Parfumerie.Services;
using System.Collections.Generic;
using Xunit;



namespace TestProject
{
    public class ProjetTest
    {
        private ProductRepository productRepository;
        private BrandRepository brandRepository;
        private List<Product> products = new List<Product>();
        private List<Brand> brands = new List<Brand>();
        private Service service;
        [Fact]
        public void TestToAddProduct()
        {
            productRepository = new ProductRepository(products);
            brandRepository = new BrandRepository(brands);
            service = new Service(productRepository, brandRepository);
            var product = new Product
            {
                Name = "product1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            service.AddProduct(product);
            Assert.NotEmpty(products);
            Assert.NotEmpty(brands);
            Assert.Contains(brands, b => b.Id == product.Brand.Id);
            Assert.Contains(products, p => p.Id == product.Id);
        }
        
        [Fact]
        public void TestToGetProduct()
        {
            productRepository = new ProductRepository(products);
            var product = new Product
            {
                Name = "product2",
                Price = 300
            };
            productRepository.Add(product);
            var testProduct = productRepository.Get(product.Id);

            Assert.NotNull(testProduct);
            Assert.Equal(product, testProduct);
            Assert.Contains(products, p=>p.Id == testProduct.Id);
            
        }
        [Fact]
        public void TestToDeleteProduct()
        {
            var productRepository = new ProductRepository(products);
            var product = new Product
            {
                Name = "prod1",
                Price = 100
            };
            productRepository.Add(product);
            productRepository.Delete(product.Id);
            

            Assert.DoesNotContain(products, p => p.Id == product.Id);
        }

        [Fact]
        public void TestToUpdateProduct()
        {

            productRepository = new ProductRepository(products);
            brandRepository = new BrandRepository(brands);
            service = new Service(productRepository, brandRepository);
            var product = new Product
            {
                Name = "product1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            productRepository.Add(product);
            var productMdf = new Product
            {
                Name = "prod1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            service.UpdateProduct(productMdf);
            Assert.Contains(products, p => p.Name == productMdf.Name);



        }
        [Fact]
        public void TestToAddPromoForPrice()
        {
            productRepository = new ProductRepository(products);

            var product = new Product
            {
                Name = "pro1",
                Price = 200
            };
            productRepository.Add(product);
            productRepository.AddPromo(product.Id,0.4);

            var expected = 120;
            Assert.Equal(expected, product.Promo);
        }

        [Fact]
        public void TestToGetAllProducts()
        {
            productRepository = new ProductRepository(products);
            var product1 = new Product
            {
                Name = "prod1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            productRepository.Add(product1);
            var product2 = new Product
            {
                Name = "prod2",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            productRepository.Add(product2);
            var expected = productRepository.GetAllProducts();

            Assert.Contains(expected, p=>p.Id == product1.Id);
            Assert.Contains(expected, p => p.Id == product2.Id);

        }
    }
}