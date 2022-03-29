// See https://aka.ms/new-console-template for more information
/*Console.WriteLine("Hello, World!");
Console.ReadKey();*/
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
using Projet_Gestion_Parfumerie.Models;
using Projet_Gestion_Parfumerie.Services;
class Program
{
    static void Main(string[] args)
    {
        Menu();
        Console.ReadLine();
        
    }
    public static List<Product> products = new List<Product>();
    public static List<Brand> brands = new List<Brand>();
    public static ProductRepository productRepository = new ProductRepository(products);
    public static BrandRepository brandRepository = new BrandRepository(brands);
    public static Service service = new Service(productRepository, brandRepository);
   public static Product product = new Product
    {
       Id = Guid.NewGuid(),
       Name = "prod1",
        Price = 200,
        Brand = new Brand
        {
            Name = "brand1"
        }
    };
    public static Product product2 = new Product
    {
        Id = Guid.NewGuid(),
        Name = "prod2",
        Price = 100,
        Brand = new Brand
        {
            Name = "brand2"
        }
    };
    public static Product product3 = new Product
    {
        Id = Guid.NewGuid(),
        Name = "prod3",
        Price = 150,
        Brand = new Brand
        {
            Name = "brand3"
        }
    };

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("welcome !!!!!!!!!!");
        Console.WriteLine("");
        Console.WriteLine("option1 : Add Product");
        Console.WriteLine("option2 : DeLete Product");
        Console.WriteLine("option3 : Update Product");
        Console.WriteLine("option4 : Get Product by Id");
        Console.WriteLine("option5 : Add Promo for product");
        Console.WriteLine("option6 : Available Product");
        Console.WriteLine("option7 : Exit");
        Console.WriteLine("choose 1 or 2 or 3 or 4 or 5 or 6 or 7");

        string option;
        option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddProduct();
                break;

            case "2":
                DeleteProduct();
                break;
            case "3":
                UpdateProduct();
                break;
            case "4":
                GetProduct();
                break;
            case "5":
                AddPromo();
                break;
            case "6":
                ProductAvailable();
                break;
            case "7":
                Exit();
                break;
        }
        Menu();
    }
   
    
    


    static void AddProduct()
    {  
        service.AddProduct(product);
        service.AddProduct(product2);
        service.AddProduct(product3);
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        };
        Console.ReadLine();
        Console.WriteLine("produit ajouté");
        Console.ReadLine();

    }
    
    static void DeleteProduct()
    {
       
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine ();
       
        productRepository.Delete(product3.Id);
       
        Console.WriteLine("product deleted");
        Console.ReadLine ();
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();
    }
    static void UpdateProduct()
    {
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();
        
        service.UpdateProduct(product);
        product.Brand.Name = "Gucci";
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();
        Console.WriteLine("product modifié");
        Console.ReadLine();
    }
    static void GetProduct()
    {
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();
        Console.WriteLine(service.GetProduct(Guid.NewGuid()).ToString()) ;
        Console.ReadLine();
        Console.WriteLine("product trouvee");
        Console.ReadLine();
    }
    static void AddPromo()
    {
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();

        service.AddPromoProduct(Guid.NewGuid(), 0.4);
        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();
        Console.WriteLine("promo added");
        Console.ReadLine();
    } 
    static void ProductAvailable()
    {

        foreach (Product p in products)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();
        Console.WriteLine("product available");
        Console.ReadLine();
    }

    static void Exit()
    {
        Console.WriteLine("exit");
        Console.ReadLine();
        System.Environment.Exit(0);
       
    }
}