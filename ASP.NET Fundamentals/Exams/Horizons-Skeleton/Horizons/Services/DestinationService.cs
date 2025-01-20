using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Models;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly ApplicationDbContext db;
        public DestinationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<IndexDestinationViewModel>> GetAllDestinationsAsync(string userId)
        {
            var destinations = await db.Destinations.Where(x => !x.IsDeleted).Select(x => new IndexDestinationViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Terrain = x.Terrain.Name,
                FavoritesCount = x.UsersDestinations.Count,
                IsFavorite = x.UsersDestinations.Any(x => x.UserId == userId),
                IsPublisher = x.PublisherId == userId,
            }).ToListAsync();
            return destinations;
        }

        public async Task<DestinationInputModel> GetAddModelAsync()
        {
            var terrains = await this.GetTerrains();

            var model = new DestinationInputModel()
            {
                Terrains = terrains,
            };
            return model;
        }

        public async Task<List<TerrainViewModel>> GetTerrains()
        {
            return await db.Terrains.Select(x => new TerrainViewModel
            {
                Name = x.Name,
                Id = x.Id
            }).ToListAsync();
        }

        public async Task AddModelAsync(DestinationInputModel model, string userId, DateTime publishedOn)
        {
            var destination = new Destination
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublisherId = userId,
                PublishedOn = publishedOn,
                TerrainId = model.TerrainId,
            };
            await db.AddAsync(destination);
            await db.SaveChangesAsync();
        }

        public async Task<DetailsDestinationView> GetDestinationDetails(int id, string userId)
        {
            var destination = await db.Destinations.Where(x => x.Id == id)
                .Select(x => new DetailsDestinationView
                {
                    ImageUrl = x.ImageUrl,
                    PublishedOn = x.PublishedOn,
                    Publisher = x.Publisher.UserName,
                    IsPublisher = x.PublisherId == userId,
                    IsFavorite = x.UsersDestinations.Any(x => x.UserId == userId),
                    Description = x.Description,
                    Id = x.Id,
                    Terrain =x.Terrain.Name,
                    Name = x.Name
                }).FirstOrDefaultAsync();

            return destination;
        }
        //public async Task<EditViewModel> GetEditModel(int id, string userId)
        //{
        //    var destination = await db.Destinations.Where(x => x.Id == id)
        //        .Select(x => new EditViewModel
        //        {
        //            ImageUrl = x.ImageUrl,
        //            PublishedOn = x.PublishedOn.ToString(),
        //            Description = x.Description,
        //            Id = x.Id,
        //            Name = x.Name
        //        }).FirstOrDefaultAsync();

        //    return destination;
        //}

        public async Task<Destination?> GetDestinationByIdAsync(int id)
        {
            return await db.Destinations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddToFavorites(string userId, Destination destination)
        {
            var userDestination = await db.UsersDestination.Where(x=> x.UserId==userId && x.DestinationId==destination.Id).FirstOrDefaultAsync();
            if (userDestination == null)
            {
                await db.UsersDestination.AddAsync(new UserDestination { DestinationId = destination.Id, UserId = userId});
                await db.SaveChangesAsync();
            }
        }
    }
}
