using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Price { get; set; }
        public Brand Brand { get; set; }
        public double PromoPrice { get; set; }
        public Product()
        {

        }
        public Product(Guid id, string name,double price,Brand brand)
        {
            Id = id;
            Name = name;
            Price = price;
            Brand = brand;
        }
    }
}
