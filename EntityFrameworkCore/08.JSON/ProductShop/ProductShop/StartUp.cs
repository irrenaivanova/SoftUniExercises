using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();
            string path = @"../../../DataSets/categories-products.json";
            string inputJsonUsers = File.ReadAllText(path);
            //string result = ImportCategoryProducts(db, inputJsonUsers);
            string result2 = GetUsersWithProducts(db);
            Console.WriteLine(result2);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {  
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>()));

            ImportUserDto[] users = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
            ICollection<User> usersForUpdate = new HashSet<User>();

            foreach (var userDto in users)
            {
                User user = mapper.Map<User>(userDto);
                usersForUpdate.Add(user);   
            }
            context.Users.AddRange(usersForUpdate);
            context.SaveChanges();
            return $"Successfully imported {usersForUpdate.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ICollection<Product> validProducts = new HashSet<Product>();
            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            foreach (var productDto in productDtos)
            {
                Product product = mapper.Map<Product>(productDto);
                validProducts.Add(product);
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return $"Successfully imported {validProducts.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
            ICollection<Category> validCategories = new HashSet<Category>();
            ImportCategoryDto[] importCategories = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
            foreach (var importDto in importCategories)
            {
                if (importDto.Name != null)
                {
                    Category category = mapper.Map<Category>(importDto);
                    validCategories.Add(category);  
                }
            }
            context.Categories.AddRange(validCategories);
            context.SaveChanges();
            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
            var catprod = JsonConvert.DeserializeObject<ImportCategoriesProductDto[]>(inputJson);
            
            context.CategoriesProducts.AddRange(mapper.Map<CategoryProduct[]>(catprod));
            context.SaveChanges();
            return $"Successfully imported {catprod.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            //var products = context.Products.Where(x=>x.Price>=500 && x.Price<1000)
            //    .OrderBy(x=>x.Price)
            //    .Select(x => new
            //    {
            //        name=x.Name,
            //        price = x.Price,
            //        seller = x.Seller.FirstName + " "+x.Seller.LastName,
            //    }).ToArray();
            //return JsonConvert.SerializeObject(products, Formatting.Indented);
            
            IMapper mapper = new Mapper(new MapperConfiguration(x=>x.AddProfile<ProductShopProfile>()));

            var products = context.Products.Where(x => x.Price >= 500 && x.Price < 1000)
                   .OrderBy(x => x.Price)
                   .ProjectTo<ExportProductPriceRangeDto>(mapper.ConfigurationProvider)
                   .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string GetSoldProducts2(ProductShopContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<ProductShopProfile>()));

            var users = context.Users.Where(x => x.ProductsSold.Count >= 1 && 
                                            x.ProductsSold.Any(y => y.Buyer != null))
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .ProjectTo<UsersWithAtEastOneSoldItemDto>(mapper.ConfigurationProvider)
                    .ToList();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(users, settings);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<ProductShopProfile>()));

            var users = context.Users.Where(x => x.ProductsSold.Count >= 1 &&
                                            x.ProductsSold.Any(y => y.Buyer != null))
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .ProjectTo<UsersWithAtEastOneSoldItemDto>(mapper.ConfigurationProvider)
                    .ToList();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            var usersValidProducts = new HashSet<UsersWithAtEastOneSoldItemDto>();
            
            foreach (var user in users)
            {
                var newUser = new UsersWithAtEastOneSoldItemDto();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.ProductsSold = new List<SoldProductDto>();

                foreach (var product in user.ProductsSold)
                {
                    if (product.BuyerLastName!=null)
                    {
                        newUser.ProductsSold.Add(product);
                    }
                }
                usersValidProducts.Add(newUser);
            }
            return JsonConvert.SerializeObject(usersValidProducts, settings);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoriesProducts.Count())
                .Select(x => new CategoriesDto
                {
                    Category = x.Name,
                    ProductsCount = x.CategoriesProducts.Count(),
                    AveragePrice = $"{x.CategoriesProducts.Average(x => x.Product.Price):f2}",
                    TotalRevenue = $"{x.CategoriesProducts.Sum(x => x.Product.Price):f2}"
                }).ToList();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(categories, settings);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.Where(x => x.ProductsSold.Any(x => x.Buyer != null))
                .Select(x => new
                {
                   
                        x.LastName,
                        x.Age,
                        SoldProducts = new
                        {
                            Count = x.ProductsSold.Where(x => x.Buyer != null).Count(),
                            Products = x.ProductsSold.Where(x => x.Buyer != null)
                        .Select(x => new
                        {
                            x.Name,
                            x.Price
                        })
                        }
                    
                }).ToList()
                .OrderByDescending(x => x.SoldProducts.Count);

            var newDtto = new
            {
                UsersCount = users.Count(),
                Users = users
            };


            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(newDtto, settings);
        }
    }
}