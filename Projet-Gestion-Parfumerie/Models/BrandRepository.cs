using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class BrandRepository : IBrandRepository
    {
       private List<Brand> Brands;
        public BrandRepository() { }
        public BrandRepository(List<Brand> brands)
        {
            this.Brands = brands;
        }
        public void AddBrand(Brand brand)
        {
            Brands.Add(brand);
        }

        public List<Brand> GetAllBrands()
        {
           return Brands;
        }

        public Brand GetBrandById(int id)
        {
            return Brands.Single(b => b.Id == id);
        }

        public Brand GetBrandByName(string name)
        {
            return Brands.Single(b => b.Name == name);
        }
    }
}
