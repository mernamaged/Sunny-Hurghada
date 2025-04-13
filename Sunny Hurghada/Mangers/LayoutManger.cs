using Microsoft.AspNetCore.Mvc;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;
namespace Sunny_Hurghada.Mangers
{
    public class LayoutManger 
    {
        private DestinationRepository destinationRepo;
        private TourTypeRepository tourTypeRepo;
        public List<string> Destinations { get; set; }
        public List<TourType> TourTypes { get; set; }
 
        public LayoutManger(DestinationRepository destinationRepository, TourTypeRepository tourTypeRepository)
        {
            destinationRepo = destinationRepository;
            tourTypeRepo = tourTypeRepository;
        }

        public List<string> GetDestinations()
        {
            Destinations = destinationRepo.GetNames();
            return Destinations;
        }
        public List<TourType> GetTourTypes()
        {
            TourTypes = tourTypeRepo.GetAll();
            return TourTypes;
        }
    }
}
