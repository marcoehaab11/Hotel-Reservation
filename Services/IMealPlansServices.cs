using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Services
{
    public interface IMealPlansServices
    {
        IEnumerable<MealPlanPerSeason> GetMealById(int mealId);

        decimal GetPriceForMeals(int mealId, DateTime checkInDate, DateTime checkOutDate);
        IEnumerable<SelectListItem> GetSelectList();
    }

}
