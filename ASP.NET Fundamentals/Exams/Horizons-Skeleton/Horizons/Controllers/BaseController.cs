using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Horizons.Controllers
{
    public class BaseController : Controller
    {
        protected string? GetUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
