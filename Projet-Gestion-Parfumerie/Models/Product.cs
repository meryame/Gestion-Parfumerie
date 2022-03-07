using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Brand Brand { get; set; }
        public double Promo { get; set; }
        public static int NbProduct = 0 ;
        public Product() 
        {
            NbProduct++;
            this.Id = NbProduct;
        }
        public Product(string name,double price,Brand brand)
        {
            NbProduct++;
            this.Id = NbProduct;
            this.Name = name;
            this.Price = price;
            this.Brand = brand;
        }
        public override string ToString()
        {
            return " " + Id + " " + Name + " " + Price+" " +Brand.Name;
        }
    }
}
