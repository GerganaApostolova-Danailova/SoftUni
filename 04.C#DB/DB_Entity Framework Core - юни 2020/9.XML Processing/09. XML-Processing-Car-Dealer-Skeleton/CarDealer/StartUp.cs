using CarDealer.Data;
using System;
using CarDealer.NewFolder;
using System.Xml.Serialization;
using System.Xml;
using CarDealer.XMLHelper;
using CarDealer.NewFolder.Import;
using System.Linq;
using CarDealer.Models;
using System.IO;
using System.Collections.Generic;
using CarDealer.NewFolder.Export;

namespace CarDealer
{
    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            //ResetDatabase(db);

            ////Problem 09

            //var usersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var result = ImportSuppliers(db, usersXml);

            ////Problem 10

            //var usersXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var result = ImportParts(db, usersXml);

            ////Problem 11

            //var usersXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var result = ImportCars(db, usersXml);

            ////Problem 12

            //var usersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var result = ImportCustomers(db, usersXml);

            ////Problem 13

            //var usersXml = File.ReadAllText("../../../Datasets/sales.xml");
            //var result = ImportSales(db, usersXml);

            ////Problem 14

            //string xml = GetCarsWithDistance(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/cars.xml", xml);

            ////Problem 15

            //string xml = GetCarsFromMakeBmw(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/bmw-cars.xml", xml);


            ////Problem 16

            //string xml = GetLocalSuppliers(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/local-suppliers.xml", xml);

            ////Problem 17

            //string xml = GetCarsWithTheirListOfParts(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/cars-and-parts.xml", xml);

            ////Problem 18

            //string xml = GetTotalSalesByCustomer(db);

            //EnsureDirectoryExists(ResultDirectoryPath);

            //File.WriteAllText(ResultDirectoryPath + "/customers-total-sales.xml", xml);

            //Problem 19

            string xml = GetSalesWithAppliedDiscount(db);

            EnsureDirectoryExists(ResultDirectoryPath);

            File.WriteAllText(ResultDirectoryPath + "/sales-discounts.xml", xml);

        }
        private static void ResetDatabase(CarDealerContext db)
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

        //Problem 19

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var resultSels = context
                .Sales
                .Select(s => new ExportSalesDiscounDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = 
                      s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            var xmlResult = XmlConverter.Serialize(resultSels,"sales");
            
            return xmlResult;
        }

        //Problem 18

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var resultCustomers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportTotalSaleCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var xmlResult = XmlConverter.Serialize(resultCustomers, "customers");

            return xmlResult;
        }

        //Problem 17

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var resultCars = context
                .Cars
                .Select(c => new ExportCarsWhitPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new CarPartsDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToList()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var resultXml = XmlConverter.Serialize(resultCars, "cars");

            return resultXml;
        }

        //Problem 16

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var resultSuppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var xmlResult = XmlConverter.Serialize(resultSuppliers, "suppliers");

            return xmlResult;
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var resultCars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportBMWCarDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var bmwCarXml = XmlConverter.Serialize(resultCars, "cars");

            return bmwCarXml;
        }

        //Problem 14

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var resultCars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var xmlResult = XmlConverter.Serialize(resultCars, "cars");

            return xmlResult;
        }

        //Problem 13

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            //<Sale>
            //    <carId>105</carId>
            //    <customerId>30</customerId>
            //    <discount>30</discount>
            //</Sale>

            var saleDto = XmlConverter
                .Deserializer<ImportSaleDto>(inputXml, "Sales");

            var carCount = context
                .Cars
                .ToArray()
                .Count();

            var sales = saleDto
                .Where(s => s.CarId <= carCount)
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";

        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var cusomersXml = XmlConverter
                .Deserializer<ImportCustomerDto>(inputXml, "Customers");

            var customers = cusomersXml
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var root = "Cars";
            var dataCars = XmlConverter.Deserializer<CarDTO>(inputXml, root);

            var cars = new List<Car>();

            foreach (var carDTO in dataCars)
            {
                var uniqueParts = carDTO.Parts.Select(p => p.partId).Distinct().ToArray();
                var realParts = uniqueParts.Where(id => context.Parts.Any(i => i.Id == id));

                var car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TraveledDistance,
                    PartCars = realParts.Select(id => new PartCar
                    {
                        PartId = id
                    })
                    .ToArray()
                };
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var resultParts = XmlConverter
                .Deserializer<ImportPartsDto>(inputXml, "Parts");

            var correctId = context
                .Suppliers
                .ToArray()
                .Count();

            var parts = resultParts
                .Where(p => p.SupplierId <= correctId)
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Problem 09

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var resultSuppliers = XmlConverter.Deserializer<ImportSuppliersDto>(inputXml, "Suppliers");

            var suppliers = resultSuppliers
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }




    }
}