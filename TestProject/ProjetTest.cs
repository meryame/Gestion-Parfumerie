using Projet_Gestion_Parfumerie.Models;
using Projet_Gestion_Parfumerie.Services;
using System;
using System.Collections.Generic;
using Xunit;



namespace TestProject
{
    public class ProjetTest 
    {
        private IProductRepository? ProductRepository;
        private IBrandRepository? BrandRepository;
        private readonly List<Product> Products = new();
        private readonly List<Brand> Brands = new();
        private Service? Service;
        [Fact]
        public void TestToAddProduct()
        {
         ProductRepository = new ProductRepository(Products);
         BrandRepository = new BrandRepository(Brands);   
         Service = new Service(ProductRepository, BrandRepository);
            
            Guid id = Guid.NewGuid();
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
            Assert.NotEmpty(Products);
            Assert.NotEmpty(Brands);
            Assert.Contains(Brands, b => b.Id == product.Brand.Id);
            Assert.Contains(Products, p => p.Id == product.Id);
        }
        
        [Fact]
        public void TestToGetProduct()
        {
            ProductRepository = new ProductRepository(Products);
            
            Guid id = Guid.NewGuid();
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
            Assert.Contains(Products, p=>p.Id == testProduct.Id);
            
        }
        [Fact]
        public void TestToDeleteProduct()
        {
            ProductRepository = new ProductRepository(Products);
            Guid id = Guid.NewGuid();
            var product = new Product
            {
                Id = id,
                Name = "prod1",
                Price = 100
            };
            ProductRepository.Add(product);
            ProductRepository.Delete(product.Id);
            

            Assert.DoesNotContain(Products, p => p.Id == product.Id);
        }

        [Fact]
        public void TestToUpdateProduct()
        {
            ProductRepository = new ProductRepository(Products);
            BrandRepository = new BrandRepository(Brands);
            Service = new Service(ProductRepository, BrandRepository);
            Guid id = Guid.NewGuid();

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
            ProductRepository.Add(product);
            var productMdf = new Product
            {
                Id = id,
                Name = "prod1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            Service.UpdateProduct(productMdf);
            Assert.Contains(Products, p => p.Name.Equals(productMdf.Name));



        }
        [Fact]
        public void TestToAddPromoForPrice()
        {
            ProductRepository = new ProductRepository(Products);
            Guid id = Guid.NewGuid();
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
            ProductRepository = new ProductRepository(Products);
           
            Guid id = Guid.NewGuid();
            var product1 = new Product
            {
                Id = id,
                Name = "prod1",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            ProductRepository.Add(product1);
            var product2 = new Product
            {
                Id = id,
                Name = "prod2",
                Price = 200,
                Brand = new Brand
                {
                    Name = "brand1"
                }
            };
            ProductRepository.Add(product2);
            var expected = ProductRepository.GetAllProducts();

            Assert.Contains(expected, p=>p.Id == product1.Id);
            Assert.Contains(expected, p => p.Id == product2.Id);

        }
    }
}