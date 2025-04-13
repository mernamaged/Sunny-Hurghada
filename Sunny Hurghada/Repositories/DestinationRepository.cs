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
        public List<Destination> GetAll()
        {
            return _context.Destinations.ToList();
        }
        public List<string> GetNames()
        {
            return _context.Destinations.Select(t => t.Name).ToList();
        }
    }
}
