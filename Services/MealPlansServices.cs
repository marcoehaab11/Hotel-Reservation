using Hotel_Reservation.Data;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Services
{
    public class MealPlansServices :IMealPlansServices 
    {
        private readonly ApplicationDbContext _context;

        public MealPlansServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.MealPlans
                .Select(m => new SelectListItem { Value = m.MealPlanId.ToString(), Text = m.MealPlanName })
                .AsNoTracking().ToList();

        }
        public IEnumerable<MealPlanPerSeason> GetMealById(int mealId)
        {
            return _context.MealPlanPerSeasons
                    .Include(e=>e.MealPlan)
                    .Include(e=>e.MealSeasonStartAndEnd)
                    .Where(x => x.MealPlanID == mealId).AsNoTracking().ToList();
        }


        public decimal GetPriceForMeals(int mealId, DateTime checkInDate, DateTime checkOutDate)
        {
            decimal price = 0;
            IEnumerable<MealPlanPerSeason> MealPlan = GetMealById(mealId);

            while (checkInDate < checkOutDate)
            {
                price += MealPlan
                                .Where(x => x.MealSeasonStartAndEnd.SeasonStartDate <= checkInDate
                                        && checkInDate <= x.MealSeasonStartAndEnd.SeasonEndDate)
                                .Select(x => x.RatePerPerson).FirstOrDefault();

                checkInDate = AddOneDay(checkInDate);
            }

            return price;
        }

        public DateTime AddOneDay(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

    }
}
