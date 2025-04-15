using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace Sunny_Hurghada.Managers
{
    public class LayoutManager
    {
        private readonly DestinationRepository _destinationRepo;
        private readonly TourTypeRepository _tourTypeRepo;
        private readonly LanguageRepository _languageRepo;

        public LayoutManager(DestinationRepository destinationRepository, TourTypeRepository tourTypeRepository,LanguageRepository languageRepository)
        {
            _destinationRepo = destinationRepository;
            _tourTypeRepo = tourTypeRepository;
            _languageRepo = languageRepository;
        }
        public int Id { get; set; }
        public async Task<List<string>> GetDestinations()
        {
            return await _destinationRepo.GetDestinationsNames();
        }

        public async Task<List<string>> GetTourTypes(int id)
        {
            Id=id;
            return await _tourTypeRepo.GetTourTypeLocalizedNames(Id);
        }
        public async Task<List<Language>> GetLanguages()
        {
            return await _languageRepo.GetAll();
        }
    }
}
