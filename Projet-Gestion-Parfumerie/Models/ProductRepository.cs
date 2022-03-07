using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class ProductRepository : IProductRepository
    {
        private  List<Product> Products;
        public ProductRepository() { }
        public ProductRepository(List<Product> products)
        {
            Products = products;
        }
        public void Add(Product Product)
        {
            if(Product == null)
            {
                throw new ArgumentNullException();
            }
            Products.Add(Product);

 
        }

        public void AddPromo(int id, double promo)
        {
            var product = Get(id);
            if (product != null)
            {
                product.Promo = promo;
                product.Price = product.Price - (product.Price * promo);
            }
        }

        public void Delete(int id)
        {
            foreach(var product in Products.ToList())
            {
                if(product.Id == id)
                {
                    Products.Remove(product);
                }
            }
           // var deleteProduct = Get(id);
            /*Products.Remove(deleteProduct);*/
        }

        public Product Get(int id)
        {
            return Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return Products.ToList() ;
        }

        public void Update(Product Product)
        {
            foreach (var product in Products)
            {
                if (product.Id == Product.Id)
                {
                    product.Name = Product.Name;
                    product.Price = Product.Price;
                    product.Brand = Product.Brand;
                }
            }
        }
    }
}
