
using ProgramsManager.DAL.Database.DBModels;

namespace ProgramsManager.DAL.Database.Seeds
{
    public class SeedDataPlate
    {
        public static List<Plate> Plates = new List<Plate>()
        {
            new Plate() { Id = Guid.NewGuid(), Name = "Blue 20", DateActivity= new DateTime(2023,2,13), Offer = true},
            new Plate() { Id = Guid.NewGuid(), Name = "Orange 20", DateActivity= new DateTime(2023,05,13), Offer = false},
            new Plate() { Id = Guid.NewGuid(), Name = "Black 20", DateActivity= new DateTime(2023,05,14), Offer = false}
        };
    }
}
