using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace Sunny_Hurghada.Pages
{
    public class Newsletter : PageModel
    {
        private readonly GuestEmailRepository guestEmailRepository;

        public Newsletter(GuestEmailRepository guestEmailRepository)
        {
            this.guestEmailRepository = guestEmailRepository;
            NewGuest = new GuestEmail();
        }
        [BindProperty]
        public GuestEmail NewGuest { get;  set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NewGuest.CreatedAt = DateTime.Now;

            guestEmailRepository.Add(NewGuest);

            return RedirectToPage();
        }
        public IActionResult OnGet()
        {
            ViewData["NewsletterModel"] = NewGuest;  // Ensure you're passing the model correctly
            return Page();
        }
    }
}
