using Microsoft.EntityFrameworkCore;
using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class TourTypeRepository
    {
        private SunnyHurghadaContext context;

        public TourTypeRepository(SunnyHurghadaContext context)
        {
            this.context= context;
        }
        public async Task<List<string>> GetTourTypeLocalizedNames(int id = 1 )
        {
            return await context.TourTypeLocalizeds
             .Where(t => t.LanguageId == id)
             .Select(t => t.Name)
             .ToListAsync();
        }
    }
}
