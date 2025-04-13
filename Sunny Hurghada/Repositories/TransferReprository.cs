using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class TransferReprository
    {
            private SunnyHurghadaContext context;

            public TransferReprository(SunnyHurghadaContext context)
            {
                this.context= context;
            }
            public void Add(TransferBooking transfer)
            {
                context.TransferBookings.Add(transfer);
                context.SaveChanges();
            }
    }
}
