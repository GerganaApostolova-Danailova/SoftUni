using Newtonsoft.Json.Converters;
using ProductShop.Data;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ProductShop.XMLHelper;
using ProductShop.Dtos.Import;
using System.Collections.Generic;
using ProductShop.Models;
using System.Linq;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            //ResetDatabase(db);

            ////Problem 01

            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var result = ImportUsers(db, usersXml);

            ////Problem 02

            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var result = ImportProducts(db, productsXml);

            ////Problem 03

            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var result = ImportCategories(db, categoriesXml);

            ////Problem 04

            //var categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var result = ImportCategoryProducts(db, categoryProductsXml);

            ////Problem 05

            //string xml = GetProductsInRange(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/products-in-range.xml", xml);

            ////Problem 06

            //string xml = GetSoldProducts(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/users-sold-products.xml", xml);

            ////Problem 07

            //string xml = GetCategoriesByProductsCount(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/categories-by-products.xml", xml);

            //Problem 08

            string xml = GetUsersWithProducts(db);

            EnsureDirectoryExists(ResultDirectoryPath);

            File.WriteAllText(ResultDirectoryPath + "/users-and-products.xml", xml);

        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("DB is deteted");
            db.Database.EnsureCreated();
            Console.WriteLine("DB is created");
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        //Problem 01

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var userResult = XmlConverter.Deserializer<ImportUsersDto>(inputXml, "Users");

            var users = new List<User>();

            foreach (var user in userResult)
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age
                };

                users.Add(newUser);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productResult = XmlConverter
                .Deserializer<ImportProductsDto>(inputXml, "Products");

            var products = new List<Product>();

            foreach (var product in productResult)
            {
                var newProduct = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    SellerId = product.SellerId,
                    BuyerId = product.BuyerId
                };

                products.Add(newProduct);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoryResult = XmlConverter
                .Deserializer<ImportCategoryDto>(inputXml, "Categories");

            var categories = new List<Category>();

            foreach (var category in categoryResult)
            {
                if (category.Name == null)
                {
                    continue;
                }

                var newCategory = new Category()
                {
                    Name = category.Name
                };
                categories.Add(newCategory);

            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoruProductResult = XmlConverter
                .Deserializer<ImportCategoryProductsDto>(inputXml, "CategoryProducts");

            var categoryProducts = new List<CategoryProduct>();

            var productIdLength = context
                .Products
                .ToArray()
                .Count();

            var categoruIdLength = context
                .Categories
                .ToArray()
                .Count();

            foreach (var cp in categoruProductResult)
            {
                if (cp.CategoryId < 1 || cp.CategoryId > categoruIdLength || cp.ProductId < 1 || cp.ProductId > productIdLength)
                {
                    continue;
                }

                var newCategoryProduct = new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                };

                categoryProducts.Add(newCategoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";

            //        < CategoryProducts >
            //< CategoryProduct >
            //    < CategoryId > 4 </ CategoryId >
            //    < ProductId > 1 </ ProductId >
            //</ CategoryProduct >
        }

        //Problem 05

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductsDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var resultXlm = XmlConverter.Serialize(products, "Products");

            return resultXlm;
        }

        //Problem 06

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new SoldProductsDto
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToList();

            var resultUsers = XmlConverter.Serialize(soldProducts, "Users");

            return resultUsers;
        }

        //Problem 07

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new CategoryByProductDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var resultXml = XmlConverter.Serialize(categories, "Categories");

            return resultXml;

        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var targetUsers = context
                .Users
                .ToList()
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUsersDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold.Select(c => new ExportProductDto
                        {
                            Name = c.Name,
                            Price = c.Price
                        })
                        .OrderByDescending(c => c.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u =>u.SoldProducts.Count)
                .Take(10)
                .ToList();
                

                var result = new ExportUserAndProductDto
                {
                    Count = context.Users.Count(x => x.ProductsSold.Any()),
                    Users = targetUsers
                };

            var resultXml = XmlConverter.Serialize(result, "Users");

            return resultXml;
        }

    }
}


