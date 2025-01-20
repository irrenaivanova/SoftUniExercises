using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Models;
using Horizons.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

using static Horizons.Common.DataConstants;

namespace Horizons.Controllers
{
    public class DestinationController : BaseController
    {
        private readonly IDestinationService service;
        private readonly ApplicationDbContext db;

        public DestinationController(IDestinationService service, ApplicationDbContext db)
        {
            this.service = service;
            this.db = db;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            DestinationInputModel model = await service.GetAddModelAsync();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(DestinationInputModel model)
        {

            bool isDateParsed = DateTime.TryParseExact(model.PublishedOn, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime publishedOn);

            if (!isDateParsed)
            {
                ModelState.AddModelError("PublishedOn", $"The date must be in following format - {DateFormat}");
            }
            if (publishedOn > DateTime.UtcNow)
            {
                ModelState.AddModelError("PublishedOn", $"The date cannot be in the future!");
            }
            if (!ModelState.IsValid)
            {
                model.Terrains = await service.GetTerrains();
                return View(model);
            }

            string userId = GetUserId()!;
            await service.AddModelAsync(model, userId, publishedOn);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            string? userId = this.GetUserId();
            List<IndexDestinationViewModel> destinations = await service.GetAllDestinationsAsync(userId);
            return View(destinations);
        }

        public async Task<IActionResult> Details(int id)
        {
            string? userId = this.GetUserId();
            DetailsDestinationView destination = await service.GetDestinationDetails(id, userId);

            if (destination == null)
            {
                return BadRequest();
            }

            return View(destination);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            Destination destination = await service.GetDestinationByIdAsync(id);
            if (destination == null)
            {
                return BadRequest();
            }
            var userId = GetUserId();
            await service.AddToFavorites(userId, destination);
            
            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }

            return RedirectToAction("Index", "Destination");
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            Destination destination = await service.GetDestinationByIdAsync(id);
            if (destination == null)
            {
                return BadRequest();
            }
            var userId = GetUserId();

            var userdestination = await db.UsersDestination.FirstOrDefaultAsync(x => x.UserId == userId && x.DestinationId==id);
            if (userdestination == null)
            {
                return BadRequest();
            }
            db.UsersDestination.Remove(userdestination);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Favorites));
        }

        [Authorize]
        public async Task<IActionResult> Favorites()
        {
            string userId = GetUserId();
            var favourites =await  db.UsersDestination.Where(x => x.UserId == userId)
                .Select(x => new FavouriteDestinationView
                {
                    Id = x.DestinationId,
                    ImageUrl = x.Destination.ImageUrl,
                    Name = x.Destination.Name,
                    Terrain = x.Destination.Terrain.Name
                }).ToListAsync();
            return View(favourites);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dest = await db.Destinations.Where(x => x.Id == id).Select(x => new DeleteViewModel
            {
                Id = x.Id,
                PublisherId = x.PublisherId,
                Publisher = x.Publisher.UserName,
                Name = x.Name,
            }).FirstOrDefaultAsync();

            if (dest==null)
            {
                return BadRequest();
            }
            string userId = GetUserId();
            if (userId != dest.PublisherId)
            {
                return Unauthorized();
            }

            return View(dest);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id, string name, string publisherId)
        {
            var dest = await db.Destinations.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dest == null)
            {
                return BadRequest();
            }
            string userId = GetUserId();
            if (userId != publisherId)
            {
                return Unauthorized();
            }
            dest.IsDeleted = true;
            db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
