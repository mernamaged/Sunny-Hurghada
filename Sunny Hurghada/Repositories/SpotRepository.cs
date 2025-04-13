using Microsoft.EntityFrameworkCore;
using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class SpotRepository
    {
        private SunnyHurghadaContext context;

        public SpotRepository(SunnyHurghadaContext context)
        {
            this.context= context;
        }
        public List<Spot> GetSpots()
        {
                var spots = context.Spots
                    .Include(s => s.SpotLocalizeds)
                    .Include(s => s.SpotImages)
                    .Include(s=>s.Destination)
                    .ToList();                      
                return spots;
        }
        public Spot GetById(int id)
        {
            return context.Spots
                .Include(s => s.SpotLocalizeds)
                .Include(s => s.SpotImages)
                .Include(s => s.Destination)
                .Include(s => s.TourType)
                .ThenInclude(t => t.TourTypeLocalizeds)
                .First(x => x.Id == id);
        }
        public decimal discountPrice(int id)
        {
            var spot = context.Spots.First(s => s.Id == id);
            var discountedPrice = spot.AdultPrice - (spot.Discount * spot.AdultPrice / 100);
            return discountedPrice;
        }
        public List<Spot> GetSpotsByToUrTypeByName(string name)
        {
            var query = context.Spots
                .Include(s => s.SpotLocalizeds)
                .Include(s => s.SpotImages)
                .Include(s => s.Destination)
                .Include(s => s.TourType)
                    .ThenInclude(tt => tt.TourTypeLocalizeds)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(s =>
                    s.TourType.TourTypeLocalizeds.First().Name == name ||s.Destination.Name == name);
            }

            return query.ToList();
        }
        public List<Spot> Search(string destination, string category)
        {
            var query = context.Spots
                .Include(s => s.SpotLocalizeds)
                .Include(s => s.SpotImages)
                .Include(s => s.Destination)
                .Include(s => s.TourType)
                    .ThenInclude(tt => tt.TourTypeLocalizeds)
                .AsQueryable();

            // Filter by destination if provided
            if (!string.IsNullOrWhiteSpace(destination) )
            {
                query = query.Where(s => s.Destination.Name == destination);
            }

            // Filter by category if provided
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(s => s.TourType.TourTypeLocalizeds.First().Name == category);
            }

            // Filter by both destination and category if both are provided
            if (!string.IsNullOrWhiteSpace(destination) && !string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(s =>
                    s.Destination.Name == destination &&
                    s.TourType.TourTypeLocalizeds.First().Name == category);
            }

            return query.ToList();
        }


    }
}
