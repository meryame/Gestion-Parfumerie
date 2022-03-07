using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Models
{
    public interface IBrandRepository
    {
        public void AddBrand(Brand brand);
        public List<Brand> GetAllBrands();
        public Brand GetBrandById(int id);
        public Brand GetBrandByName(string name);
    }
}
