using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string DirectoryPath = "../../../Datasets/Result";

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            //ResetDatabase(db);

            ////Problem 09

            //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");

            //string result = ImportSuppliers(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 10

            //string inputJson = File.ReadAllText("../../../Datasets/parts.json");

            //string result = ImportParts(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 11

            //string inputJson = File.ReadAllText("../../../Datasets/cars.json");

            //string result = ImportCars(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 12

            //string inputJson = File.ReadAllText("../../../Datasets/customers.json");

            //string result = ImportCustomers(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 13

            //string inputJson = File.ReadAllText("../../../Datasets/sales.json");

            //string result = ImportSales(db, inputJson);

            //Console.WriteLine(result);

            ////Problem 14

            //string json = GetOrderedCustomers(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/ordered-customers.json", json);

            ////Problem 15

            //string json = GetCarsFromMakeToyota(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/toyota-cars.json", json);

            ////Problem 16

            //string json = GetLocalSuppliers(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/local-suppliers.json", json);

            ////Problem 17

            //string json = GetCarsWithTheirListOfParts(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/cars-and-parts.json", json);

            ////Problem 18

            //string json = GetTotalSalesByCustomer(db);

            //if (!Directory.Exists(DirectoryPath))
            //{
            //    Directory.CreateDirectory(DirectoryPath);
            //}

            //File.WriteAllText(DirectoryPath + "/customers-total-sales.json", json);

            //Problem 19

            string json = GetSalesWithAppliedDiscount(db);

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(DirectoryPath + "/sales-discounts.json", json);

        }
        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("DB is deteted");
            db.Database.EnsureCreated();
            Console.WriteLine("DB is created");
        }


        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        //Problem 10

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppllierCount = context.Suppliers.Count();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(x => x.SupplierId <= suppllierCount);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //Problem 11

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);
            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {

                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,

                };
                cars.Add(newCar);

                foreach (var carPartId in carDto.PartsId.Distinct())
                {
                    var newCarPart = new PartCar()
                    {
                        PartId = carPartId,
                        Car = newCar
                    };
                    carParts.Add(newCarPart);
                }

            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported { cars.Count()}.";
        }

        //Problem 12

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert
                .DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //Problem 13

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert
               .DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        //Problem 14

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customer = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(customer, Formatting.Indented);

            return json;
        }

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Problem 16

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        //Problem 17

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(cp => new
                    {
                        Name = cp.Part.Name,
                        Price = cp.Part.Price.ToString("F2")
                    })
                    .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(y => y.Car.PartCars.Sum(x => x.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Problem 19

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var cars = context
                .Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = s.Car.PartCars.Sum(x => x.Part.Price).ToString("F"),
                    priceWithDiscount = (s.Car.PartCars.Sum(x => x.Part.Price) * (1M - s.Discount / 100M)).ToString("F")
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }
    }
}