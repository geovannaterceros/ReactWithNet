
using System.ComponentModel.DataAnnotations;

namespace ProgramsManager.Models.Models.Plate
{
    public class PlateCreateDto
    {
        public string Name { get; set; }

        public DateTime DateActivity { get; set; }

        public bool Offer { get; set; }

        public string UIDUser { get; set; }

        public List<Guid> OrdersIds { get; set; }
    }
}
