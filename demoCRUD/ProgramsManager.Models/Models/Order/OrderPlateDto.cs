
using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.Models.Models.Order
{
    public class OrderPlateDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrdenId { get; set; }

        public Guid PlateId { get; set; }

        public OrderDto Order { get; set; }

        public PlateDto Plate { get; set; }
    }
}
