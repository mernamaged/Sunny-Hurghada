using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class ListingModel : PageModel
    {
        private readonly SpotRepository spotRepository;
        private readonly GuestEmailRepository guestEmailRepository;
        public ListingModel (SpotRepository spotRepository, GuestEmailRepository guestEmailRepository)
        {
            this.spotRepository = spotRepository;
            this.guestEmailRepository = guestEmailRepository;
        }
        [FromRoute]
        public int Id { get; set; }
        [FromRoute]
        public string Name { get; set; } = string.Empty;
        [BindProperty]
        public int TotalSpots { get; private set; }
        public List<Spot> spotsbyname { get; private set; }

        public void OnGet(int id,string name )
        {
            Id = id;
            Name = name;
            spotsbyname = spotRepository.GetSpotsByToUrTypeByName(name);
            TotalSpots = spotRepository.GetSpotsByToUrTypeByName(name).Count();

        }
        [BindProperty]
        public GuestEmail NewGuest { get; set; }

        public IActionResult OnPost()
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
