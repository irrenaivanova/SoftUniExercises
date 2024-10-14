using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Homies.Data.Models.DataConstants;


namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public EventController(HomiesDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var events = await db.Events.Select(x => new CardViewModel
            {
                Id = x.Id,
                Start = x.Start.ToString(DateTimeFormat),
                Name = x.Name,
                Type = x.Type.Name,
                Organiser = x.Organiser.UserName
            }).ToListAsync();

            return View(events);
        }
        [Authorize]
        public async Task<IActionResult> Joined()
        {
            var events = await db.Events.Where(x => x.Organiser.UserName == User.Identity!.Name || x.EventsParticipants.Any(x => x.Helper.UserName == User.Identity.Name))
                .Select(x => new CardViewModel
                {
                    Id = x.Id,
                    Start = x.Start.ToString(DateTimeFormat),
                    Name = x.Name,
                    Type = x.Type.ToString()!,
                    Organiser = x.Organiser.UserName
                }).ToListAsync();

            return View(events);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            CreateEventInput input = await GetModelWithTypes();
            return View(input);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateEventInput input)
        {
            bool isStartDateValid = DateTime
                .TryParseExact(input.Start, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            if (!isStartDateValid)
            {
                ModelState.AddModelError(nameof(input.Start), String.Format("The Start Date must be in the following format: {0}", DateTimeFormat));
            }

            bool isEndDateValid = DateTime
               .TryParseExact(input.End, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (!isEndDateValid)
            {
                ModelState.AddModelError(nameof(input.End), $"The End Date must be in the following format: {DateTimeFormat}");
            }

            if (endDate <= startDate)
            {
                ModelState.AddModelError(nameof(input.End), "The End Date must be after the Start Date!");
            }


            if (!ModelState.IsValid)
            {
                CreateEventInput inputwithTypes = await GetModelWithTypes();
                return View(inputwithTypes);
            }

            var user = await userManager.GetUserAsync(User);
            var eventToAdd = new Event
            {
                Name = input.Name,
                Start = startDate,
                End = endDate,
                Description = input.Description,
                TypeId = input.TypeId,
                OrganiserId = user.Id,
                CreatedOn = DateTime.UtcNow
            };

            await db.Events.AddAsync(eventToAdd);
            db.SaveChanges();

            return RedirectToAction(nameof(All));
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await userManager.GetUserAsync(User);
            Event eventToEdit = await db.Events.FirstOrDefaultAsync(x => x.OrganiserId == user.Id && x.Id == id);
            if (eventToEdit == null)
            {
                return RedirectToAction(nameof(All));
            }
            var types = await db.Types.ToListAsync();
            var eventToEditModel = new CreateEventInput()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start.ToString(),
                End = eventToEdit.End.ToString(),
                Types = types,
                TypeId = eventToEdit.TypeId,
                Id = id
            };

            return View(eventToEditModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(CreateEventInput input)
        {
            var user = await userManager.GetUserAsync(User);
            Event eventToEdit = await db.Events.FirstOrDefaultAsync(x => x.OrganiserId == user.Id && x.Id == input.Id);

            if (eventToEdit == null)
            {
                return RedirectToAction(nameof(All));
            }

            // TODO Checking the Date in private method
            bool isStartDateValid = DateTime
               .TryParseExact(input.Start, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            if (!isStartDateValid)
            {
                ModelState.AddModelError(nameof(input.Start), String.Format("The Start Date must be in the following format: {0}", DateTimeFormat));
            }

            bool isEndDateValid = DateTime
               .TryParseExact(input.End, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (!isEndDateValid)
            {
                ModelState.AddModelError(nameof(input.End), $"The End Date must be in the following format: {DateTimeFormat}");
            }

            if (endDate <= startDate)
            {
                ModelState.AddModelError(nameof(input.End), "The End Date must be after the Start Date!");
            }

            if (!ModelState.IsValid)
            {
                var types = await db.Types.ToListAsync();
                input.Types = types;
                return View(input);
            }

            eventToEdit.Name = input.Name;
            eventToEdit.Description = input.Description;
            eventToEdit.Start = startDate;
            eventToEdit.End = endDate;
            eventToEdit.TypeId = input.TypeId;
            db.SaveChanges();

            return RedirectToAction(nameof(All));
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Join(int? id)
        {
            var @event = await db.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (@event == null)
            {
                return RedirectToAction(nameof(All));
            }
            var user = await userManager.GetUserAsync(User);

            if (@event.OrganiserId == user.Id || db.EventParticipants.Any(x=>x.HelperId==user.Id && x.EventId==@event.Id))
            {
                return RedirectToAction(nameof(All));
            }

            await db.EventParticipants.AddAsync(new EventParticipant() { EventId=@event.Id,HelperId=user.Id});
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Joined));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Leave(int? id)
        {
            var @event = await db.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (@event == null)
            {
                return RedirectToAction(nameof(All));
            }
            var user = await userManager.GetUserAsync(User);
            var eventpart = await db.EventParticipants.FirstOrDefaultAsync(x => x.EventId == @event.Id && x.HelperId == user.Id);

            if (eventpart==null)
            {
                return RedirectToAction(nameof(Joined));
            }

            db.EventParticipants.Remove(eventpart!);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Joined));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var @event = await db.Events.Include(x=>x.Type)
                .Include(x=>x.Organiser)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (@event == null)
            {
                return RedirectToAction(nameof(All));
            }
            var eventDetails = new EventDetails()
            {
                Id = @event.Id,
                Description = @event.Description,
                Start = @event.Start.ToString(DateTimeFormat),
                End = @event.End.ToString(DateTimeFormat),
                CreatedOn = @event.CreatedOn.ToString(DateTimeFormat),
                Type = @event.Type.Name,
                Organiser = @event.Organiser.UserName

            };
            return View(eventDetails);
        }




        private async Task<CreateEventInput> GetModelWithTypes()
        {

            var types = await db.Types.ToListAsync();
            var eventModel = new CreateEventInput
            {
                Types = types
            };
            return eventModel;
        }
    }
}
