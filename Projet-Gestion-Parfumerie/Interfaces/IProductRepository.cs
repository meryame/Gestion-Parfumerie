using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public interface IProductRepository
    {
        public void Add(Product Product);
        public void Delete(Guid id);
        public Product? Get(Guid id);
        public List<Product> GetAllProducts();
        public void AddPromo(Guid id, double promo);
    }
}
