using Sunny_Hurghada.Models;

namespace Sunny_Hurghada.Repositories
{
    public class PaymentRepository
    {
        private SunnyHurghadaContext context;

        public PaymentRepository(SunnyHurghadaContext context)
        {
            this.context= context;
        }
        public void Add(Payment NewPayment)
        {
            context.Payments.Add(NewPayment);
            context.SaveChanges();
        }
    }
}
