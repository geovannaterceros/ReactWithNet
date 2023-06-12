
using ProgramsManager.DAL.Database.DBModels;

namespace ProgramsManager.DAL.Database.Seeds
{
    public class SeedDataPlate
    {
        public static List<Plate> Plates = new List<Plate>()
        {
            new Plate() { Id = Guid.NewGuid(), Name = "Blue 20", DateActivity= new DateTime(2023,2,13), Offer = true, UIDUser= "DnwdIFJ3jpYiYqWnyNYAS5nb88g2"},
        };
    }
}
