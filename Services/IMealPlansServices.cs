using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Services
{
    public interface IMealPlansServices
    {
        IEnumerable<MealPlanPerSeason> GetMealById(int mealId);
        IEnumerable<SelectListItem> GetSelectList();
        string GetMealPlanNameById(int meadId);
        public decimal MealPriceForReservation(DateTime checkInDate, DateTime checkOutDate, int mealPlanId, int numberOfAdult, int numberOfChildren);
    }

}
