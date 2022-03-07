using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class Brand
    {
        public int Id { get; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public static int NbBrand;
        public Brand() 
        {
            NbBrand++;
            this.Id = NbBrand;
        }
        public Brand(string name,List<Product> products)
        {
            NbBrand++;
            this.Id = NbBrand;
            this.Name = name;
            Products = products;
        }
    }
}
