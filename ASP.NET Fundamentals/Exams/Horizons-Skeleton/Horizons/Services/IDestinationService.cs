using Horizons.Data.Models;
using Horizons.Models;

namespace Horizons.Services
{
    public interface IDestinationService
    {
        Task<List<IndexDestinationViewModel>> GetAllDestinationsAsync(string userId);

        Task<DestinationInputModel> GetAddModelAsync();

        Task<List<TerrainViewModel>> GetTerrains();

        Task AddModelAsync(DestinationInputModel model, string userId, DateTime publishedOn);

        Task<DetailsDestinationView> GetDestinationDetails(int id, string userId);

        Task<Destination?> GetDestinationByIdAsync(int id);

        Task AddToFavorites(string userId, Destination destination);

        //Task<EditViewModel> GetEditModel(int id, string userId);
    }
}
