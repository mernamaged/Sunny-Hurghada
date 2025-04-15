using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ContactRepository _contactRepository;

        public ContactModel(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [BindProperty]
        public ContactU NewContact { get; set; }

        public IActionResult OnPostContact()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contactRepository.Add(NewContact);

            // TODO: Redirect to a confirmation or payment page after submission
            return RedirectToPage(); // Example redirection (update as needed)
        }
    }
}

