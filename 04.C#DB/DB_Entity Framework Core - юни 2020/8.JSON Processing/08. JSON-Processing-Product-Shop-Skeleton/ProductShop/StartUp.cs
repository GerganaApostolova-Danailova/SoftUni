using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string DirectoryPath = "../../../Datasets/Result";
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            // ResetDatabase(db);

            ////Problem 01

            //string inputJson = File.ReadAllText("../../../Datasets/users.json");

            //string result = ImportUsers(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 02

            //string inputJson = File.ReadAllText("../../../Datasets/products.json");

            //string result = ImportProducts(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 03

            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");

            //string result = ImportCategories(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 04

            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //string result = ImportCategoryProducts(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 05

            //string json = GetProductsInRange(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/products-in-range.json", json);

            ////Problem 06

            //string json = GetSoldProducts(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/users-sold-products.json", json);

            ////Problem 07

            //string json = GetCategoriesByProductsCount(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/categories-by-products.json", json);

            //Poblem 08

            string json = GetUsersWithProducts(db);

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(DirectoryPath + "/users-and-products.json", json);
        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("DB is deteted");
            db.Database.EnsureCreated();
            Console.WriteLine("DB is created");
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Length}";
        }

        //Problem 02

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert
                .DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 03

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert
                .DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //Problem 04

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert
                .DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        //Problem 05

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(products,
                Formatting.Indented);

            return json;
        }

        //Problem 06

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context
                .Users
                .Where(u => u.ProductsSold.Any(y => y.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                                  .Where(y => y.Buyer != null)
                                  .Select(ps => new
                                  {
                                      name = ps.Name,
                                      price = ps.Price,
                                      buyerFirstName = ps.Buyer.FirstName,
                                      buyerLastName = ps.Buyer.LastName
                                  })
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //Problem 07

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(x => x.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(x => x.Product.Price).ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var targetUsers = context.Users
                .AsEnumerable()
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count(c => c.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(b => b.Buyer != null),
                        products = x.ProductsSold.Where(b => b.Buyer != null).Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        }).ToList()
                    }
                })
                .ToList();

            var usersResultObj = new
            {
                usersCount = targetUsers.Count,
                users = targetUsers,
            };

            return JsonConvert.SerializeObject(usersResultObj,
                                               new JsonSerializerSettings
                                               {
                                                   Formatting = Formatting.Indented,
                                                   NullValueHandling = NullValueHandling.Ignore
                                               }
                                              );
        }
    }
}