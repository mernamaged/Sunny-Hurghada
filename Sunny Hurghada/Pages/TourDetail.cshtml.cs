using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada.Pages
{
    public class TourDetailModel : PageModel
    {
        private readonly SpotRepository spotRepository;
        private readonly PaymentRepository _paymentRepository;
        public TourDetailModel(SpotRepository spotRepository, PaymentRepository paymentRepository)
        {
            this.spotRepository = spotRepository;
            _paymentRepository = paymentRepository;
        }
        public int Id { get; set; }
        public int LanguageId { get; set; }
        [BindProperty]
        public Spot SpotList { get; set; }
        public decimal DiscountPrice { get; private set; }
        [BindProperty]
        public SpotBooking NewSpotBooking { get; set; }

        [BindProperty]
        public Payment NewPayment { get; set; }
        public void OnGet(int id,int languageId)
        {
            Id = id;
            LanguageId = languageId;
            SpotList = spotRepository.GetById(Id,LanguageId);
            DiscountPrice = spotRepository.DiscountPrice(Id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                NewPayment.Status = "Failed";
                return Page();
            }

            NewPayment.Status = "Success";
            NewPayment.CreatedAt = DateTime.Now;
            NewPayment.TotalAmount= TotalAmount();
            _paymentRepository.Add(NewPayment);

            NewPayment.Id= NewSpotBooking.PaymentId ;
            spotRepository.Add(NewSpotBooking);

            return Page();
        }
        public decimal TotalAmount()

        {
            decimal AdultsPrice = SpotList.AdultPrice * NewSpotBooking.Adults;
            decimal ChildrenPrice = SpotList.ChildPrice * NewSpotBooking.Children;
            return AdultsPrice+ ChildrenPrice;
        }
    }
}
