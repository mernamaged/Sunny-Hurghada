using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class TransferModel : PageModel
    {
        private readonly GuestEmailRepository guestEmailRepository;
        private readonly TransferReprository transferReprository;

        public TransferModel(GuestEmailRepository guestEmailRepository,TransferReprository transferReprository )
        {
            this.guestEmailRepository = guestEmailRepository;
            this.transferReprository = transferReprository;

        }
        [BindProperty]
        public GuestEmail NewGuest { get; set; }
        [BindProperty]
        public TransferBooking NewTransfer { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            NewTransfer.PaymentId = 10; //TODO: Get the payment ID from the session or database  
            transferReprository.Add(NewTransfer);

            //TODO:Redirtect to payment page page
            return Page();
        }
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
