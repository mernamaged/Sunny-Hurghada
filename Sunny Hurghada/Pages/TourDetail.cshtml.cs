using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class TourDetailModel : PageModel
    {
        private readonly SpotRepository spotRepository;
        private readonly GuestEmailRepository guestEmailRepository;
        public TourDetailModel(SpotRepository spotRepository , GuestEmailRepository guestEmailRepository)
        {
            this.spotRepository = spotRepository;
            this.guestEmailRepository = guestEmailRepository;
        }
        public int Id { get; set; }
        [BindProperty]
        public Spot SpotList { get; set; }
        public decimal DiscountPrice { get; private set; }

        public void OnGet(int id)
        {
            Id = id;
            SpotList = spotRepository.GetById(Id);
            DiscountPrice = spotRepository.discountPrice(Id);
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
