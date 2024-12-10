using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static DeskMarket.Common.DataConstants;

namespace DeskMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;

        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ProductInputModel> GetAddModelAsync()
        {
            var categories = await db.Categories
                .Select(x => new CategoryInput
                {
                    Name = x.Name,
                    Id = x.Id,
                }).ToListAsync();

            var model = new ProductInputModel()
            {
                Categories = categories
            };
            return model;
        }

        public async Task AddModelAsync(ProductInputModel model, string userId, DateTime addedOn)
        {
         
            var product = new Product
            {
                ProductName = model.ProductName,
                Description = model.Description,
                SellerId = userId,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                AddedOn = addedOn,
                CategoryId = model.CategoryId
            };
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
        }

       

        public async Task<List<ProductIndexPageViewModel>> GetProductList(string userId)
        {
            var products = await db.Products.Select(x => new ProductIndexPageViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                IsSeller = userId == x.SellerId,
                //HasBought = x.ProductClient.Any(y => y.ProductId == x.Id)
                HasBought = x.IsDeleted
            }).ToListAsync();

            return products;
        }

        public async Task AddToCartAsync(int id, string userId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return;
            }
            bool isAlreadyAdded = await db.ProductClients.AnyAsync(x => x.ProductId == id && x.ClientId == userId);
            if (isAlreadyAdded)
            {
                return;
            }
            var productClient = new ProductClient
            {
                ProductId = id,
                ClientId = userId
            };
            await db.ProductClients.AddAsync(productClient);
            await db.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int id, string userId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return;
            }
            var productClient = await db.ProductClients.FirstOrDefaultAsync(x => x.ProductId == id && x.ClientId == userId);
            if (productClient == null)
            {
                return;
            }

            db.ProductClients.Remove(productClient);
            await db.SaveChangesAsync();


        }

        public async Task<List<CartModelView>> ShowCartItemAsync(string userId)
        {
            return await db.ProductClients.Where(x => x.ClientId == userId).Select(x => new CartModelView
            {
                ImageUrl = x.Product.ImageUrl,
                ProductName = x.Product.ProductName,
                Price = x.Product.Price,
                Id = x.ProductId
            }).ToListAsync();
        }


        public async Task<DetailProductViewModel> DetailsOfProduct(int id)
        {
            var product =await  db.Products.Where(x => x.Id == id)
                .Select(x => new DetailProductViewModel
                {
                    ImageUrl = x.ImageUrl,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    Id = x.Id,
                    AddedOn = x.AddedOn.ToString(DateTimeFormat),
                    CategoryName = x.Category.Name,
                    Seller = x.Seller.UserName,
                    HasBought = x.IsDeleted,
                    Description = x.Description
                }).FirstOrDefaultAsync();
            return product;
        }

        public async Task DeleteItemFromDataBAse(DeleteProductViewModel model)
        {
            var productToRemove = await db.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            db.Products.Remove(productToRemove);
            await db.SaveChangesAsync();
        }


        public async Task<DeleteProductViewModel> DeleteItem(int id,string userId)
        {
            var item = await db.Products.Where(x=>x.Id==id)
                .Select(x=> new DeleteProductViewModel
                {
                   Id = x.Id,
                   Seller = x.Seller.UserName,
                   ProductName = x.ProductName,
                   SellerId= x.SellerId
                }).FirstOrDefaultAsync();
            return item;
        }
        public async Task<List<CategoryInput>> GetCategories()
        {
            return  await db.Categories
                .Select(x => new CategoryInput
                {
                    Name = x.Name,
                    Id = x.Id,
                }).ToListAsync();
        }
    }
}
