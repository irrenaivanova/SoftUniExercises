using AutoMapper;
using AutoMapper.QueryableExtensions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();
            string xml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            string result = ImportCategoryProducts(db, xml);
            Console.WriteLine(result);
            string result2 = GetUsersWithProducts(db);
            Console.WriteLine(result2);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var xml = new XmlHelper();
            var users = xml.Deserialize<UserDto>(inputXml);
            
            var validUsers = new HashSet<User>();

            foreach (var user in users)
            {
                if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
                {
                    continue;
                }
                validUsers.Add(mapper.Map<User>(user));
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();
            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var xml = new XmlHelper();
            var products = xml.Deserialize<ProductDto>(inputXml);
            var validProducts = new HashSet<Product>();
            var ids = context.Users.Select(x => x.Id);
            
            foreach (var product in products)
            {
                if (string.IsNullOrEmpty(product.Name) || 
                    !product.Price.HasValue || 
                    !product.SellerId.HasValue)
                {
                    continue;
                }
                //if (!ids.Any(x=>x==product.SellerId) || !ids.Any(x => x == product.BuyerId))
                //{
                //    continue;
                //}

                validProducts.Add(mapper.Map<Product>(product));
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var xml = new XmlHelper();  

            var catergories = xml.Deserialize<CategoryDto>(inputXml);
            var validCat = new HashSet<Category>();
            foreach (var item in catergories)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }
                validCat.Add(mapper.Map<Category>(item));
            }

            context.Categories.AddRange(validCat);
            context.SaveChanges();
            return $"Successfully imported {validCat.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            var xml = new XmlHelper();  
            var productcategories = xml.Deserialize<CategoryProductDto>(inputXml);
            var validCategories = new HashSet<CategoryProduct>();
            var categoryIds = context.Categories.Select(c => c.Id); 
            var productIds = context.Products.Select(p => p.Id);
           
            foreach (var item in productcategories) 
            {
                if (!categoryIds.Any(x=>x==item.CategoryId))
                {
                    continue;
                }
                if (!productIds.Any(x => x == item.ProductId))
                {
                    continue;
                }
                validCategories.Add(mapper.Map<CategoryProduct>(item));
            }
            context.AddRange(validCategories); 
            context.SaveChanges();
            return $"Successfully imported {validCategories.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            var products = context.Products.Where(x=>x.Price>=500 && x.Price<=1000)
                .OrderBy(x=>x.Price)
                .Take(10)
                .ProjectTo<Product1>(mapper.ConfigurationProvider)
                .ToArray();

            var xml = new XmlHelper();
            return xml.Serialize(products, "Products");     
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            var xml = new XmlHelper();
            var users = context.Users.Where(x => x.ProductsSold.Count > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Include(x=>x.ProductsSold)
                .ProjectTo<User6>(mapper.ConfigurationProvider).ToArray();

            return xml.Serialize(users, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            var xml = new XmlHelper();
            var categories = context.Categories
                .Include(x => x.CategoryProducts)
                .ThenInclude(x => x.Product)
                .ProjectTo<Category7>(mapper.ConfigurationProvider)
                .ToArray()
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            return xml.Serialize(categories, "Categories");
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var xml = new XmlHelper();
            var users = context.Users.Where(x=>x.ProductsSold.Count>0)
                .OrderByDescending(x=>x.ProductsSold.Count)
                .Select(x=>new User88
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    ProductsSold = new Product8
                    {
                        Count = x.ProductsSold.OrderByDescending(x => x.Price).Take(10).Count(),
                        Products = x.ProductsSold.OrderByDescending(x => x.Price).Take(10).Select(y => new Product88
                        {
                            Name = y.Name,
                            Price = y.Price
                        }).ToList(),
                    }
                }).ToList();
            var user8 = new User8()
            {
                Count = users.Count(),
                Users = users.Select(x=>x).Take(10).ToList(),
            };

            return xml.Serialize(user8, "Users");
        }

        public static IMapper CreateMapper()
                 => new Mapper(new MapperConfiguration(x => x.AddProfile<ProductShopProfile>()));
    }
}