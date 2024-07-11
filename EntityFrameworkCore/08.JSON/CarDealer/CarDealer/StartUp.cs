using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result1 = ImportSales(db,inputJson);
            //Console.WriteLine(result1);
            string result2 = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(result2);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>()));
            var jsonSupllier = JsonConvert.DeserializeObject<SupplierDto[]>(inputJson);
            
            var validSuppliers = mapper.Map<Supplier[]>(jsonSupllier);
            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();
            return $"Successfully imported {validSuppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x=>x.AddProfile<CarDealerProfile>()));  
            var parts = JsonConvert.DeserializeObject<PartsDto[]>(inputJson);
            ICollection<Part> validParts = new HashSet<Part>();
            foreach (var part in parts)
            {
                if (!context.Suppliers.Any(x=>x.Id==part.SupplierId))
                {
                    continue;
                }
                var validPart = mapper.Map<Part>(part);
                validParts.Add(validPart);
            }
            
            context.Parts.AddRange(validParts);
            context.SaveChanges();
            return $"Successfully imported {validParts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        { 
            var jsonCars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
            var validPartCars = new HashSet<PartCar>();
            var validCars = new HashSet<Car>();

            foreach (var car in jsonCars)
            {
                var validCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TraveledDistance = car.TraveledDistance
                };

                validCars.Add(validCar);

                foreach (var part in car.PartsId.Distinct())
                {
                    var partCar = new PartCar();
                    partCar.Car = validCar;
                    partCar.PartId = part;
                    validPartCars.Add(partCar);
                }
            }

            context.PartsCars.AddRange(validPartCars);
            context.Cars.AddRange(validCars);
            context.SaveChanges();
            return $"Successfully imported {validCars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<CarDealerProfile>()));
            var customerJson = JsonConvert.DeserializeObject<CustomerDto[]>(inputJson);   
            var validCustomers = mapper.Map<Customer[]>(customerJson);
            context.AddRange(validCustomers);
            context.SaveChanges();
            return $"Successfully imported {validCustomers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesJson = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.AddRange(salesJson);
            context.SaveChanges();
            return $"Successfully imported {salesJson.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers.OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x=>new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    x.IsYoungDriver
                    
                })
                .ToList();
            return JsonConvert.SerializeObject(customers,Formatting.Indented);  
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<CarDealerProfile>()));

            var cars = context.Cars.Where(x => x.Make == "Toyota")
                .OrderBy(x=>x.Model)
                .ThenByDescending(x=>x.TraveledDistance)
                .ToList();
            var carsDto = mapper.Map<ExportCarDto[]>(cars);
            return JsonConvert.SerializeObject(carsDto,Formatting.Indented);

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<CarDealerProfile>()));
            var suppliers = context.Suppliers.Where(x => !x.IsImporter)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider).ToList();
           
            return JsonConvert.SerializeObject (suppliers,Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<CarDealerProfile>()));
            var cars = context.Cars
                .Include(x=>x.PartsCars)
                .ThenInclude(x=>x.Part)
                .ProjectTo<CarWithParts>(mapper.ConfigurationProvider).ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts2(CarDealerContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<CarDealerProfile>()));
            var cars = context.Cars.Select(x => new
            {
                PartsCar = x.PartsCars.Select(x=>x.Part)
            })
  
                .ProjectTo<CarWithParts>(mapper.ConfigurationProvider).ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
        //with two nested sum -  Ef can not translate it
        public static string GetTotalSalesByCustomer2(CarDealerContext context)
        {
            var costumers = context.Customers.Where(x => x.Sales.Any())
                   .Select(x => new
                   {
                       fullName = x.Name,
                       boughtCars = x.Sales.Count(),
                       spentMoney = x.Sales.Sum(x => x.Car.PartsCars.Sum(x => x.Part.Price))
                   }).ToList();

            return JsonConvert.SerializeObject(costumers, Formatting.Indented); 
        }
        //with LazyLoading, this can be rewritten with combination of eager loading and projection
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var costumers = context.Customers.Where(x => x.Sales.Any())
                   .Select(x => new
                   {
                       x.Name,
                       sales = x.Sales
                   }).ToList()
                   .Select(x => new
                   {
                       fullName = x.Name,
                       boughtCars = x.sales.Count(),
                       spentMoney = x.sales.Sum(x => x.Car.PartsCars.Sum(x => x.Part.Price))
                   })
                   .OrderByDescending(x=>x.spentMoney)
                   .ThenByDescending(x=>x.boughtCars)
                   .ToList();

            return JsonConvert.SerializeObject(costumers, Formatting.Indented);
        }
        
        
        //using eager loading and DTOs - again Ef can not translate it - manual mapping is the solution
        public static string GetTotalSalesByCustomer3(CarDealerContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<CarDealerProfile>()));
            var customers = context.Customers.Where(x => x.Sales.Count > 0)
                .Include(x => x.Sales)
                .ThenInclude(x => x.Car)
                .ThenInclude(x => x.PartsCars)
                .ThenInclude(x => x.Part)
                .ProjectTo<ExportCostumerDtoByMoneySPend>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<CarDealerProfile>()));
            var sales = context.Sales.Take(10)
                .Include(x => x.Customer)
                .Include(x => x.Car)
                .ThenInclude(x => x.PartsCars)
                .ThenInclude(x => x.Part)
                .ProjectTo<SalesDto>(mapper.ConfigurationProvider).ToList();

            return JsonConvert.SerializeObject(sales,Formatting.Indented);
        }
    }
}