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
            if (Product == null)
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

            var deleteProduct = Get(id);
            if (deleteProduct != null)
            {
                _poducts.Remove(deleteProduct);
            }
            
        }

        public Product? Get(Guid id) => _poducts.SingleOrDefault(p => p.Id.Equals(id));
          
        

        public List<Product> GetAllProducts() => _poducts;
    }
}
