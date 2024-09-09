using Hotel_Reservation.Models;
using Hotel_Reservation.Services;
using Hotel_Reservation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel_Reservation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMealPlansServices _mealServices;
        private readonly IRoomsServices _roomsServices;
        private readonly IReservationServices _reservationServices;

        public HomeController(IMealPlansServices mealServices, IRoomsServices roomsServices, IReservationServices reservationServices)
        {
            _mealServices = mealServices;
            _roomsServices = roomsServices;
            _reservationServices = reservationServices;
        }

        public IActionResult Index()
        {
            CreateReservationFromViewModel viewModel = new CreateReservationFromViewModel()
            {
                RoomTypies = _roomsServices.GetSelectList(),
                MealPlans = _mealServices.GetSelectList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(CreateReservationFromViewModel createReservation)
        {
            if (!ModelState.IsValid)
            {
                createReservation.RoomTypies = _roomsServices.GetSelectList();
                createReservation.MealPlans = _mealServices.GetSelectList();
                return View(createReservation);
            }
             decimal Total =  _reservationServices.GetReservationTotal(createReservation.CheckInDate, createReservation.CheckOutDate,
                createReservation.NumberOfAdult, createReservation.NumberOfChildren, createReservation.RoomTypeId, createReservation.MealPlanId);


            return Json(Total.ToString());
        }
    }
}
