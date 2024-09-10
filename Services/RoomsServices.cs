﻿using Hotel_Reservation.Data;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Services
{
    public class RoomsServices : IRoomsServices
    {   
        private readonly ApplicationDbContext _context;

        public RoomsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomSeason> GetAll()
        {
            return _context.RoomSeasons.
                Include(e=>e.RoomSeasonStartAndEnds)
                .Include(e=>e.Rooms)
                .AsNoTracking().ToList();
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Rooms
                .Select(m => new SelectListItem { Value = m.RoomTypeId.ToString(), Text = m.RoomTypeName })
                .AsNoTracking().ToList();

        }
        public IEnumerable<RoomSeason> GetRoomById(int id)
        {
            return GetAll().Where(e => e.RoomTypeId == id);
        }
        public string GetRoomNameById(int roomId)
        {
            return _context.Rooms
                .Where(e => e.RoomTypeId == roomId)
                .Select(e => e.RoomTypeName)
                .AsNoTracking().FirstOrDefault();
        }
        private decimal GetRoomPriceForOnePerson(int roomTypeId, DateTime checkInDate, DateTime checkOutDate)
        {
            decimal price = 0;
            IEnumerable<RoomSeason> MealPlan = GetRoomById(roomTypeId);

            while (checkInDate < checkOutDate)
            {
                price += MealPlan
                                .Where(x => x.RoomSeasonStartAndEnds.SeasonStartDate<= checkInDate
                                        && checkInDate <= x.RoomSeasonStartAndEnds.SeasonEndDate)
                                .Select(x => x.RatePerRoom).FirstOrDefault();

                checkInDate = AddOneDay(checkInDate);
            }

            return price;
        }
        public decimal RoomPriceForReservation(DateTime checkInDate, DateTime checkOutDate, int roomTypeId, int numberOfGuests)
        {
            return numberOfGuests * GetRoomPriceForOnePerson(roomTypeId, checkInDate, checkOutDate);
        }
     
        private DateTime AddOneDay(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        
    }
}
