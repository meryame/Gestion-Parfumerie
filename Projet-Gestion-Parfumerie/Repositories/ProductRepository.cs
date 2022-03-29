using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class ProductRepository : IProductRepository
    {
        private  List<Product> _poducts;
        
        public ProductRepository(List<Product> products)
        {
            _poducts = products;
        }
        public void Add(Product Product)
        {
            if(Product == null)
            {
                throw new ArgumentNullException();
            }
            _poducts.Add(Product);

 
        }

        public void AddPromo(Guid id, double promo)
        {
            var product = Get(id);
            if (product != null)
            {
                product.PromoPrice = product.Price*(1-promo);    
            }
        }
        public void Delete(Guid id)
        {
            _poducts.RemoveAll(x => x.Id.Equals(id));
           // var deleteProduct = Get(id);
            /*Products.Remove(deleteProduct);*/
        }

        public Product? Get(Guid id)
        {
            return _poducts.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Product> GetAllProducts()
        {
            return _poducts;
        }

        public void Update(Product Product)
        {
            // todo : refactor
            var p = Get(Product.Id);
            if (p != null)
            {
                p.Name = Product.Name;
                p.Price = Product.Price;
                p.Brand = Product.Brand;
            }

           /* foreach (var product in _poducts)
            {
                if (product.Id == Product.Id)
                {
                    product.Name = Product.Name;
                    product.Price = Product.Price;
                    product.Brand = Product.Brand;
                }
            }*/
        }
    }
}
