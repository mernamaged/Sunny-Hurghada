using Sunny_Hurghada.Models;
namespace Sunny_Hurghada.Repositories
{
    public class ContactRepository
    {
        private SunnyHurghadaContext context;

        public ContactRepository(SunnyHurghadaContext context)
        {
            this.context= context;
        }
        public void Add(ContactU contact)
        {
            context.ContactUs.Add(contact);
            context.SaveChanges();
        }
    }
}
