using Microsoft.EntityFrameworkCore;
using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class DestinationRepository
    {
        private SunnyHurghadaContext _context;
        public DestinationRepository(SunnyHurghadaContext context)
        {
            _context = context;
        }
        public async Task< List<Destination>> GetAll()
        {
            return await _context.Destinations.ToListAsync();
        }
        public async Task<List<string>> GetDestinationsNames()
        {
            return await _context.Destinations.Select(t => t.Name).ToListAsync();
        }
    }
}
