using Microsoft.EntityFrameworkCore;
using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class LanguageRepository
    {
        private SunnyHurghadaContext _context;
        public LanguageRepository(SunnyHurghadaContext context)
        {
            _context = context;
        }
        public async Task<List<Language>> GetAll()
        {
            return await _context.Languages.ToListAsync();
        }
    }
}
