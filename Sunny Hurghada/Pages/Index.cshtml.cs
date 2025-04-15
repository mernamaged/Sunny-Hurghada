using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DestinationRepository _destinationRepo;
        private readonly SpotRepository _spotRepo;
        private readonly TourTypeRepository _tourTypeRepo;

        public List<Destination> Destinations { get; set; }
        public List<string> TourTypeNames { get; set; }

        [BindProperty]
        public List<Spot> SpotResults { get; set; } = new();
        public List<string> DestinationNames { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedDestination { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }
        public int Id { get; set; }
        public IndexModel(
            DestinationRepository destinationRepository,
            SpotRepository spotRepository,
            TourTypeRepository tourTypeRepository)
        {
            _destinationRepo = destinationRepository;
            _spotRepo = spotRepository;
            _tourTypeRepo = tourTypeRepository;
        }

        public async Task OnGet(string destination, string TourType,int id =1)
        {
            Id = id;
            SelectedDestination = destination;
            SelectedCategory = TourType;
            DestinationNames = await _destinationRepo.GetDestinationsNames();
            TourTypeNames = await _tourTypeRepo.GetTourTypeLocalizedNames(Id);
            SpotResults = await _spotRepo.GetSearchResults(SelectedDestination, SelectedCategory);
            Destinations = await _destinationRepo.GetAll();
        }
    }
}
