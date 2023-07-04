
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.Models.Models.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; } 

        public int NumberOrder { get; set; }

        public List<OrderPlateDto> OrdensPlates { get; set; } 

        public List<PlateDto> Plates { get; set; }
    }
}
