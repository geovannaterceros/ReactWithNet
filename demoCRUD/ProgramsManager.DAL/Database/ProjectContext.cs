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

        public virtual DbSet<Plate> Plates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plate>().ToTable("Plate");
            modelBuilder.Entity<Plate>().HasData(SeedDataPlate.Plates);
        }
    }
}
