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
        public void Add(GuestEmail email)
        {
            context.GuestEmails.Add(email);
            context.SaveChanges();
        }
    }
}
