using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class SpotRepository
    {
        private readonly SunnyHurghadaContext _context;

        public SpotRepository(SunnyHurghadaContext context)
        {
            _context = context;
        }

        private IQueryable<Spot> GetAllSpotsQuery()
        {
            return _context.Spots
                .Include(s => s.SpotLocalizeds)
                .Include(s => s.SpotImages)
                .Include(s => s.Destination)
                .Include(s => s.TourType)
                    .ThenInclude(tt => tt.TourTypeLocalizeds);
        }

        public async Task<List<Spot>> GetAllSpots()
        {
            return await GetAllSpotsQuery().ToListAsync();
        }

        public Spot GetById(int id ,int languageId)
        {
            return GetAllSpotsQuery()
                .First(x => x.Id == id);
        }

        public decimal DiscountPrice(int id)
        {
            var spot = _context.Spots.First(s => s.Id == id);
            return spot.AdultPrice - (spot.Discount * spot.AdultPrice / 100);
        }

        public async Task <List<Spot>> GetSpotsByDropdownChoice(string name)
        {
            var query = GetAllSpotsQuery();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(s =>
                    s.TourType.TourTypeLocalizeds.Any(tt => tt.Name == name) ||
                    s.Destination.Name == name);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Spot>> GetSearchResults(string destination, string tourType)
        {
            var query = GetAllSpotsQuery();

            if (!string.IsNullOrWhiteSpace(destination))
            {
                query = query.Where(s => s.Destination.Name == destination);
            }

            if (!string.IsNullOrWhiteSpace(tourType))
            {
                query = query.Where(s => s.TourType.TourTypeLocalizeds.Any(l => l.Name == tourType));
            }

            return await query.ToListAsync();
        }
        public void Add(SpotBooking spotBooking)
        {
            _context.SpotBookings.Add(spotBooking);
            _context.SaveChanges();
        }
    }
}
