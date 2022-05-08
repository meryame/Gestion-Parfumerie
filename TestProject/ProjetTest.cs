using Projet_Gestion_Parfumerie.Models;
using Projet_Gestion_Parfumerie.Services;
using System;
using System.Collections.Generic;
using Xunit;



namespace TestProject
{
    public class ProjetTest 
    {
        private IProductRepository ProductRepository;
        private IBrandRepository BrandRepository;
        private List<Product> products = new List<Product>();
        private List<Brand> brands = new List<Brand>();
        private Service Service;
        public ProjetTest(IProductRepository productRepository,IBrandRepository brandRepository,Service service)
        {
            ProductRepository = productRepository;
            BrandRepository = brandRepository;
            Service = service;
        }

        [Fact]
        public void TestToAddProduct()
        {    
            var id = Guid.NewGuid();
            var product = new Product
            {
                Id = id,
                Name = "product1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            Service.AddProduct(product);
            Assert.NotEmpty(products);
            Assert.NotEmpty(brands);
            Assert.Contains(brands, b => b.Id == product.Brand.Id);
            Assert.Contains(products, p => p.Id == product.Id);
        }
        
        [Fact]
        public void TestToGetProduct()
        {
            var id = Guid.NewGuid();
            var product = new Product
            {
                Id = id,
                Name = "product2",
                Price = 300
            };
            ProductRepository.Add(product);
            var testProduct = ProductRepository.Get(product.Id);

            Assert.NotNull(testProduct);
            Assert.Equal(product, testProduct);
            Assert.Contains(products, p=>p.Id == testProduct.Id);
            
        }
        [Fact]
        public void TestToDeleteProduct()
        {
            var id = Guid.NewGuid();
            var product = new Product
            {
                Id = id,
                Name = "prod1",
                Price = 100
            };
            ProductRepository.Add(product);
            ProductRepository.Delete(product.Id);
            

            Assert.DoesNotContain(products, p => p.Id == product.Id);
        }
        [Fact]
        public void TestToAddPromoForPrice()
        {
            var id = Guid.NewGuid();
            var product = new Product
            {
                Id = id,    
                Name = "pro1",
                Price = 200
            };
            ProductRepository.Add(product);
            ProductRepository.AddPromo(product.Id,0.4);

            var expected = 120;
            Assert.Equal(expected,product.PromoPrice);
        }

        [Fact]
        public void TestToGetAllProducts()
        {
            var id = Guid.NewGuid();
            var natural = new Product
            {
                Id = id,
                Name = "prod1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            ProductRepository.Add(natural);
            var evidence = new Product
            {
                Id = id,
                Name = "prod2",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            ProductRepository.Add(evidence);
            var expected = ProductRepository.GetAllProducts();
            Assert.Contains(expected, p=>p.Id == natural.Id);
            Assert.Contains(expected, p => p.Id == evidence.Id);

        }
    }
}