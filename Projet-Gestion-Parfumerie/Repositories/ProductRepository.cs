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
        public bool Add(Product Product)
        {
            if (Product == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _poducts.Add(Product);
            }
             return true;
        }

        public void AddPromo(Guid id, double promo)
        {
            var product = Get(id);
            if (product != null)
            {
                product.PromoPrice = product.Price*(1-promo);    
            }
        }
        public bool Delete(Guid id)
        {

            var deleteProduct = Get(id);
            if (deleteProduct != null)
            {
                _poducts.Remove(deleteProduct);
            }
            return true;
        }

        public Product? Get(Guid id)
        {
            return _poducts.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Product> GetAllProducts()
        {
            return _poducts;
        }

        public bool Update(Product Product)
        {
            // todo : refactor
            var ModifiedProduct = Get(Product.Id);
            if (ModifiedProduct != null)
            {
                ModifiedProduct.Name = Product.Name;
                ModifiedProduct.Price = Product.Price;
                ModifiedProduct.Brand = Product.Brand;
            }
            return true;
        }
    }
}
