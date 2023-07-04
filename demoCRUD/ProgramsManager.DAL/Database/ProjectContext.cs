using Microsoft.EntityFrameworkCore;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.DAL.Database.Seeds;

namespace ProgramsManager.DAL.Database
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
      : base(options)
        {

        }

        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Plate> Plates { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderPlate> OrdersPlates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           // modelBuilder.Entity<Plate>().HasData(SeedDataPlate.Plates);

            modelBuilder.Entity<Restaurant>().ToTable("Restaurant");
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Plate>().ToTable("Plate");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderPlate>().ToTable("OrderPlate");
        }
    }
}
