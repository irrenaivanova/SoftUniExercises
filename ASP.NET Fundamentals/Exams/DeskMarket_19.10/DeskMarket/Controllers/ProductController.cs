using DeskMarket.Models;
using DeskMarket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static DeskMarket.Common.DataConstants;

namespace DeskMarket.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ProductInputModel model = await service.GetAddModelAsync();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(ProductInputModel model)
        {
            bool isDateParsed = DateTime.TryParseExact(model.AddedOn, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime addedOn);

            if (!isDateParsed)
            {
                ModelState.AddModelError("AddedOn", $"The date must be in following format - {DateTimeFormat}");
            }
            if (addedOn > DateTime.UtcNow)
            {
                ModelState.AddModelError("AddedOn", $"The date cannot be in the future!");
            }
            if (!ModelState.IsValid)
            {
                model.Categories = await service.GetCategories();
                return View(model);
            }
            string userId = GetUserId();
            await service.AddModelAsync(model, userId, addedOn);
            return RedirectToAction(nameof(Index));     
        }


        public async Task<IActionResult> Index()
        {
            string userId = this.GetUserId();
            List<ProductIndexPageViewModel> products = await service.GetProductList(userId);
            return View(products);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = GetUserId();
            await service.AddToCartAsync(id,userId);
            return RedirectToAction(nameof(Cart));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = GetUserId();
            await service.RemoveFromCartAsync(id, userId);
            return RedirectToAction(nameof(Cart));
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();
            List<CartModelView> items =  await service.ShowCartItemAsync(userId);
            return View(items);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string userId = GetUserId();
            var items = await service.DeleteItem(id, userId);
            return View(items);
        }
       
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            string userId = GetUserId();
            await service.DeleteItemFromDataBAse(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            string userId = GetUserId();
            var product = await service.DetailsOfProduct(id);
            return View(product);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = GetUserId();
            List<CartModelView> items = await service.ShowCartItemAsync(userId);
            return View(items);
        }

    }
}
