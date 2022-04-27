using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public interface IProductRepository
    {
        public bool Add(Product Product);
        public bool Update(Product Product);
        public bool Delete(Guid id);
        public Product? Get(Guid id);
        public List<Product> GetAllProducts();
        public void AddPromo(Guid id, double promo);
    }
}
