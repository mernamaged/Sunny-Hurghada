using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class ListingModel : PageModel
    {
        private readonly SpotRepository _spotRepository;

        public ListingModel(SpotRepository spotRepository)
        {
            _spotRepository = spotRepository;
        }

        [FromRoute]
        public int Id { get; set; }

        [FromRoute]
        public string Name { get; set; } = string.Empty;
        public int LanguageId { get; set; }
        [BindProperty]
        public int TotalSpotsSelected { get; private set; }

        public List<Spot> SelectedSpot { get; private set; }

        public async Task  OnGet(int id, string name,int languageId)
        {
            Id = id;
            Name = name;
            LanguageId= languageId;
            SelectedSpot = await _spotRepository.GetSpotsByDropdownChoice(name);

            TotalSpotsSelected = SelectedSpot.Count;
        }
    }
}
