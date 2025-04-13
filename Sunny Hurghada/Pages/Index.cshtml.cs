using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages;

public class IndexModel : PageModel
{
    private readonly DestinationRepository destinationRepo;
    private readonly SpotRepository spotRepository;
    private readonly TourTypeRepository tourTypeRepository;
    private readonly GuestEmailRepository guestEmailRepository;

    public List<Destination> Destinations { get; set; }
    public List<Spot> SpotsName { get; set; }
    public List<TourType> TourTypeNames { get; set; }
    [BindProperty]
    public GuestEmail NewGuest { get; set; }
    public List<Spot> FilteredTours { get; set; }
    [BindProperty(SupportsGet = true)]
    public string SelectedDestination { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SelectedCategory { get; set; } 

    public IndexModel( DestinationRepository destinationRepository, SpotRepository spotRepository,TourTypeRepository tourTypeRepository,GuestEmailRepository guestEmailRepository)
    {
        destinationRepo = destinationRepository;
        this.spotRepository=spotRepository;
        this.tourTypeRepository = tourTypeRepository;
        this.guestEmailRepository = guestEmailRepository;
    }

    public void OnGet(string destination , string category)
    {
        SelectedDestination = destination;
        SelectedCategory = category;
        TourTypeNames = tourTypeRepository.GetAll();
        Destinations = destinationRepo.GetAll();
        SpotsName = spotRepository.GetSpots();
        FilteredTours = spotRepository.Search(SelectedDestination, SelectedCategory);
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
