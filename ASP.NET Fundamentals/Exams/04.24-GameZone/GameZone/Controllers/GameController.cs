using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using static GameZone.Data.Models.DataConstants.Common;
namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext db;

        public GameController(GameZoneDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var games = await db.Games.Select(x => new GameViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                Genre = x.Genre.Name,
                ReleasedOn = x.ReleasedOn.ToString(DateTimeFormat),
                Publisher = x.Publisher.UserName
            }).AsNoTracking().ToListAsync();

            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var userId = GetUserId();
            var games = await db.GamerGames.Where(x=>x.GamerId==userId)
                .Select(x => new GameViewModel
            {
                Id = x.Game.Id,
                Title = x.Game.Title,
                ImageUrl = x.Game.ImageUrl,
                Genre = x.Game.Genre.Name,
                ReleasedOn = x.Game.ReleasedOn.ToString(DateTimeFormat),
                Publisher = x.Game.Publisher.UserName
            }).AsNoTracking().ToListAsync();

            return View(games);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameInputModel();
            var genres = await GetGenres();
            model.Genres = genres;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameInputModel model)
        {
            bool isTheDateParsed = DateTime.TryParseExact(model.ReleasedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releasedDate);
            if (!isTheDateParsed)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), $"The Release Date must be in format {DateTimeFormat}");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var game = new Game()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                ReleasedOn = releasedDate,
                GenreId = model.GenreId,
                PublisherId = GetUserId()
            };
            await db.AddAsync(game);
            await db.SaveChangesAsync();    

            return RedirectToAction (nameof(All));
        }
        
        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
           
            var game = await db.Games.FindAsync(id);
            if (game==null)
            {
                return RedirectToAction(nameof(All));
            }
            var userId = GetUserId();
            var gameGamer = await db.GamerGames.FirstOrDefaultAsync(x => x.GameId == id && x.GamerId == userId);
            if(gameGamer!=null)
            {
                return RedirectToAction(nameof(All));
            }
            db.GamerGames.Add(new GamerGame(){GameId =  id,GamerId=userId});
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
        }

        public async Task<IActionResult> StrikeOut(int id)
        {
            var game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return RedirectToAction(nameof(All));
            }
            var userId = GetUserId();
            var gameGamer = await db.GamerGames.FirstOrDefaultAsync(x => x.GameId == id && x.GamerId == userId);
            
            if (gameGamer == null)
            {
                return RedirectToAction(nameof(All));
            }
            db.Remove(gameGamer);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await db.Games.FindAsync(id);
            if (game==null)
            {
                return RedirectToAction(nameof(All));
            }
            if (game.PublisherId!=GetUserId())
            {
                return Unauthorized();
            }
            var genres = await GetGenres();
            
            var model = new GameInputModel()
            {
                Title = game.Title,
                ImageUrl = game.ImageUrl,
                ReleasedOn = game.ReleasedOn.ToString(DateTimeFormat),
                Description = game.Description,
                GameId = game.Id,
                GenreId = game.GenreId,
                Genres = genres
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameInputModel model, int id)
        {
            bool isTheDateParsed = DateTime.TryParseExact(model.ReleasedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releasedDate);
            if (!isTheDateParsed)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), $"The Release Date must be in format {DateTimeFormat}");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                model.Genres = await GetGenres();
                return View(model);
            }
           
            var game = await db.Games.FindAsync(id);
            if (game.PublisherId!= GetUserId()) 
            { 
                return Unauthorized(); 
            
            }
            
            game.Title= model.Title;
            game.ImageUrl= model.ImageUrl;
            game.Description = model.Description;
            game.ReleasedOn = releasedDate;
            game.GenreId = model.GenreId;
            
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(All))
;        }

        public async Task<IActionResult> Details(int id)
        {
            var game = await db.Games.Include(x => x.Genre).Include(x=>x.Publisher).FirstOrDefaultAsync(x=>x.Id==id);
            if (game==null)
            {
                return RedirectToAction(nameof(All));
            }
            var model = new DetailsViewModel()
            {
                Description = game.Description,
                ImageUrl= game.ImageUrl,
                Title = game.Title,
                Genre = game.Genre.Name,
                ReleasedOn = game.ReleasedOn.ToString(DateTimeFormat),
                Publisher= game.Publisher.UserName,
                Id = game.Id
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await db.Games.Include(x => x.Publisher).FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return RedirectToAction(nameof(All));
            }

            var model = new DeleteViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Publisher = game.Publisher.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteViewModel model)
        {
            var game = await db.Games.FirstOrDefaultAsync(x=>x.Id==model.Id);
            if (game == null)
            {
                return RedirectToAction(nameof(All));
            }
            var gamerGames = await db.GamerGames.Where(x=>x.GameId==game.Id).ToListAsync();
            db.GamerGames.RemoveRange(gamerGames);
            db.Games.Remove(game);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult GetAvailableTimes(string date)
        {
            // Your logic to calculate available times
            DateTime selectedDate = DateTime.Parse(date);
            var availableTimes = new List<string>();

            if (selectedDate.DayOfWeek == DayOfWeek.Monday)
            {
                availableTimes = new List<string> { "09:00", "10:00", "11:00" };
            }
            else
            {
                availableTimes = new List<string> { "14:00", "15:00", "16:00" };
            }

            return Json(new { availableTimes });
        }


        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty; 
        }

        private Task<List<Genre>> GetGenres()
        {
            return db.Genres.AsNoTracking().ToListAsync();
        }
    }
}
