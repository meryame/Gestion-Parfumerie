using Projet_Gestion_Parfumerie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Parfumerie.Services
{
    public class Service
    {
        private IProductRepository _productRepository;
        private IBrandRepository _brandRepository;

        public Service(IProductRepository productRepository,IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
            if (product != null)
            {
                _brandRepository.AddBrand(product.Brand);
            
            }

        }

        public Product GetProduct(int id)
        {
            return _productRepository.Get(id);
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.Delete(product.Id);
            var brandRemove = _brandRepository.GetBrandByName(product.Brand.Name);
            if (brandRemove != null)
            {
                brandRemove.Products.Remove(product);
            }


        }
        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);

        }
       public void AddPromoProduct(int id,double promo)
        {
            _productRepository.AddPromo(id,promo);
        }
        
    }
}
