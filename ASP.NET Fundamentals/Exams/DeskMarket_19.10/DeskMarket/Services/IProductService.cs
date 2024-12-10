using DeskMarket.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeskMarket.Services
{
    public interface IProductService
    {
        public Task<ProductInputModel> GetAddModelAsync();

        public  Task<List<ProductIndexPageViewModel>> GetProductList(string userId);

        public Task AddModelAsync(ProductInputModel model, string userId, DateTime addedOn);

        public Task<List<CategoryInput>> GetCategories();

        public Task AddToCartAsync(int id, string userId);

        public Task RemoveFromCartAsync(int id, string userId);

        public Task<List<CartModelView>> ShowCartItemAsync(string userId);

        public Task<DetailProductViewModel> DetailsOfProduct(int id);
        public Task<DeleteProductViewModel> DeleteItem(int id, string userId);
        public Task DeleteItemFromDataBAse(DeleteProductViewModel model);
    }
}
