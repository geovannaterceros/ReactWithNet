using ProgramsManager.Models.Interfaces;
using ProgramsManager.Models.Models.Order;

namespace ProgramsManager.Models.Models.Plate
{
    public class PlateDto : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateActivity { get; set; }

        public bool Offer { get; set; }

        public string UIDUser { get; set; }

        public Guid MenuId { get; set; }

        public List<OrderPlateDto> OrdersPlates { get; set; }

        public List<OrderDto> Orders{ get; set; }
    }
}
