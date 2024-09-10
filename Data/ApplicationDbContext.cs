using Hotel_Reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealPlanPerSeason>()
           .HasKey(e => new { e.MealPlanID, e.MealSeasonStartAndEndID });

            modelBuilder.Entity<MealPlanPerSeason>()
                .HasOne(e => e.MealPlan)
                .WithMany(e => e.MealPlanPerSeason)
                .HasForeignKey(e => e.MealPlanID);


            modelBuilder.Entity<MealPlanPerSeason>()
                .HasOne(e => e.MealSeasonStartAndEnd)
                .WithMany(e => e.MealPlanPerSeason)
                .HasForeignKey(e => e.MealSeasonStartAndEndID);


            modelBuilder.Entity<RoomSeason>()
                .HasKey(e=>new {e.RoomTypeId,e.RoomSeasonStartAndEndID });

            modelBuilder.Entity<RoomSeason>()
                .HasOne(e => e.Rooms)
                .WithMany(e => e.RoomSeasons)
                .HasForeignKey(e => e.RoomTypeId);

            modelBuilder.Entity<RoomSeason>()
                .HasOne(e => e.RoomSeasonStartAndEnds)
                .WithMany(e => e.RoomSeasons)
                .HasForeignKey(e => e.RoomSeasonStartAndEndID);
        }
    
       public DbSet<Reservation> Reservations { get; set; }


       public DbSet<RoomType> Rooms { get; set; }
       public DbSet<RoomSeason> RoomSeasons { get; set; }
       public DbSet<RoomSeasonStartAndEnd> RoomSeasonStartAndEnds { get; set; }


       public DbSet<MealPlan> MealPlans { get; set; }
       public DbSet<MealPlanPerSeason> MealPlanPerSeasons { get; set; }
       public DbSet<MealSeasonStartAndEnd> MealSeasonStartAndEndSeasons { get; set; }
       
      



    }
}
