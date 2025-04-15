using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class GuestEmailRepository
    {
        private SunnyHurghadaContext context;

        public GuestEmailRepository(SunnyHurghadaContext context)
        {
            this.context= context;
        }
        public void Add(GuestEmail guestEmail)
        {
            context.GuestEmails.Add(guestEmail);
            context.SaveChanges();
        }
    }
}
