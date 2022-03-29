using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class Brand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public static int NbBrand;
        public Brand() 
        {
           
        }
        public Brand(Guid id,string name,List<Product> products)
        {
          
            this.Id = id;
            this.Name = name;
            Products = products;
        }
    }
}
