using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class ContactModel : PageModel
    {
        private ContactRepository _contactRepository;
        private GuestEmailRepository guestEmailRepository;

        public ContactModel(ContactRepository contactRepository,GuestEmailRepository guestEmailRepository)
        {
            _contactRepository = contactRepository;
            this.guestEmailRepository = guestEmailRepository;
        }

        [BindProperty]
        public ContactU NewContact { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            _contactRepository.Add(NewContact);
           
            //TODO:Redirtect to payment page page
            return Page();
        }
        [BindProperty]
        public GuestEmail NewGuest { get; set; }
        public IActionResult OnPostEmail()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NewGuest.CreatedAt = DateTime.Now;

            guestEmailRepository.Add(NewGuest);

            return Page();
        }
    }
}
