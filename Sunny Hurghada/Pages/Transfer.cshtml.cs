using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class TransferModel : PageModel
    {
        private readonly TransferReprository _transferRepository;
        private readonly PaymentRepository _paymentRepository;

        public TransferModel(TransferReprository transferRepository, PaymentRepository paymentRepository)
        {
            _transferRepository = transferRepository;
            _paymentRepository = paymentRepository;
        }

        [BindProperty]
        public TransferBooking NewTransfer { get; set; }

        [BindProperty]
        public Payment NewPayment { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                NewPayment.Status = "Failed";
                return Page();
            }

            NewPayment.Status = "Success";
            NewPayment.CreatedAt = DateTime.Now;
            _paymentRepository.Add(NewPayment);

            NewTransfer.PaymentId = NewPayment.Id;
            _transferRepository.Add(NewTransfer);

            return Page();
        }
    }
}
