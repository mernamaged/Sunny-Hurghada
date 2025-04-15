using Microsoft.AspNetCore.Mvc;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace Sunny_Hurghada.Controllers
{
    public class SubscriptionController : Controller
    {
        public readonly GuestEmailRepository guestEmailRepository;
        public SubscriptionController(GuestEmailRepository guestEmailRepository)
        {
            this.guestEmailRepository = guestEmailRepository;
        }

        [HttpPost]
        public IActionResult SubmitEmail([FromForm] GuestEmail guestEmail)
        {
            guestEmailRepository.Add(guestEmail);
            guestEmail.CreatedAt = DateTime.Now;

            return RedirectToPage("/Index"); // Make sure "Home" controller exists
        }
    }
}

