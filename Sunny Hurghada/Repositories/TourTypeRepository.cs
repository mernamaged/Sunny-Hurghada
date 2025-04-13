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
        public List<TourType> GetAll()
        {
            return context.TourTypes.Include(l=> l.TourTypeLocalizeds).ToList();
        }
    }
}
