using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.DTOs.Export;
using CarDealer.Models;
using CarDealer.Utilities;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
            //string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            //string result = ImportSales(db,inputXml);
            //Console.WriteLine(result);

            string result2 = GetTotalSalesByCustomer(db);
            Console.WriteLine(result2);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(x => x.AddProfile<CarDealerProfile>());
            var mapper = new Mapper(config);
            var serializer = new XmlSerializer(typeof(ImportSupllyDto[]), new XmlRootAttribute("Suppliers"));
            StringReader stringReader = new StringReader(inputXml);
            var supplyDto = (ImportSupllyDto[])serializer.Deserialize(stringReader);
            ICollection< Supplier > valid = new HashSet< Supplier >();
            foreach (var supply in supplyDto)
            {
                valid.Add(mapper.Map<Supplier>(supply));
            }
            context.Suppliers.AddRange(valid);
            context.SaveChanges();
            return $"Successfully imported {valid.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            var serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));
            using StringReader reader = new StringReader(inputXml);
            var parts = (ImportPartDto[])serializer.Deserialize(reader);
            ICollection<Part> validParts = new HashSet<Part>();
            
            foreach (var part in parts)
            {
                if (!context.Suppliers.Any(x=>x.Id==part.supplierId))
                {
                    continue;
                }
                validParts.Add(mapper.Map<Part>(part));
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();
            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportParts2(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var parts = new XMLSerializer().Deserialise<ImportPartDto>(inputXml);

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (var part in parts)
            {
                if (!context.Suppliers.Any(x => x.Id == part.supplierId))
                {
                    continue;
                }
                validParts.Add(mapper.Map<Part>(part));
            }

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var serializer= new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("Cars"));
            using StringReader reader = new StringReader(inputXml);
            var carsDto = (ImportCarDto[])serializer.Deserialize(reader);
            ICollection<Car> validCars = new HashSet<Car>();
            
            foreach (var carDto in carsDto)
            {
                if (string.IsNullOrEmpty(carDto.Make) || string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }
                Car car = mapper.Map<Car>(carDto);

                foreach (var part in carDto.Parts.DistinctBy(x=>x.PartId))
                {
                    if (!context.Parts.Any(x=>x.Id==part.PartId))
                    {
                        continue;
                    }

                    var partCar = mapper.Map<PartCar>(part);
                    car.PartsCars.Add(partCar);
                }
                validCars.Add(car);
            }
           context.Cars.AddRange(validCars);
            context.SaveChanges();
            return $"Successfully imported {validCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var serializitor = new XmlSerializer(typeof(ImportCostumerDto[]), new XmlRootAttribute("Customers"));
            using var reader = new StringReader(inputXml);
            var customersDto = (ImportCostumerDto[])serializitor.Deserialize(reader);
            var validcustomers = mapper.Map<Customer[]>(customersDto);
            context.Customers.AddRange(validcustomers);
            context.SaveChanges();
            return $"Successfully imported {validcustomers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var ser = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            var saleDto = (ImportSaleDto[])ser.Deserialize(new StringReader(inputXml));
            var validSales = new HashSet<Sale>();
            foreach (var sale in saleDto)
            {
                if (!context.Cars.Any(x=>x.Id==sale.CarId))
                    {
                    continue;
                }
                
                validSales.Add(mapper.Map<Sale>(sale));
            }

            context.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            IMapper mapper = CreateMapper();
            var cars = context.Cars.Where(x => x.TraveledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            var carDtos = mapper.Map<ExportCarDto[]>(cars);
            var ser = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, carDtos, ns);
            return sb.ToString().Trim();


        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            IMapper mapper = CreateMapper();
            var cars = context.Cars.Where(x=>x.Make=="BMW")
                .OrderBy(x=>x.Model)
                .ThenByDescending(x=>x.TraveledDistance)
                .ProjectTo<CarBmwDto>(mapper.ConfigurationProvider).ToArray();
            XMLHelper helper = new XMLHelper();
            return helper.Serialize(cars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            var suppliers = context.Suppliers.Where(x=>!x.IsImporter)
                .ProjectTo<NotImporter>(mapper.ConfigurationProvider).ToArray();
            var xmlHelper = new XMLHelper();
            return xmlHelper.Serialize(suppliers, "suppliers");

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            var cars = context.Cars.OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .Include(x => x.PartsCars)
                .ThenInclude(x => x.Part)
                .ToArray()
                .Select(x =>
                {
                    var carDto = mapper.Map<Car1>(x);
                    carDto.Parts = carDto.Parts.OrderByDescending(x => x.Price).ToList();
                    return carDto;
                })
                .ToArray();


            var ser = new XMLHelper();
            return ser.Serialize(cars, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            var ser = new XMLHelper();

            var customers = context.Customers.Where(x => x.Sales.Count > 0)
                .Select(x => new Customer1()
                {
                    FullName = x.Name,
                    BoughtCar = x.Sales.Count,
                    SpentMoney = x.Sales.ToArray().Sum(x => x.Car.PartsCars.Sum(x => x.Part.Price))

                }).ToArray()
                .OrderByDescending(x => x.SpentMoney);

            return ser.Serialize(customers, "customers");

        }




        public static IMapper CreateMapper()
            =>new Mapper(new MapperConfiguration(x=>x.AddProfile<CarDealerProfile>()));
    }
}


