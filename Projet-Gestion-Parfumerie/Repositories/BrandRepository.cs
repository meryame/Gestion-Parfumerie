using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public class BrandRepository : IBrandRepository
    {
       private List<Brand> _brands;
        
        public BrandRepository(List<Brand> brands)
        {
            this._brands = brands;
        }
        public void AddBrand(Brand brand)
        {
            _brands.Add(brand);
        }

        public List<Brand> GetAllBrands()
        {
           return _brands;
        }

        public Brand GetBrandById(Guid id)
        {
            return _brands.Single(b => b.Id.Equals(id));
        }

        public Brand GetBrandByName(string name)
        {
            return _brands.Single(b => b.Name == name);
        }
    }
}
