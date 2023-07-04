using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.Models.Models.Menu
{
    public class MenuDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }


        public Guid RestaurantId { get; set; }

        public List<PlateDto> Plates { get; set; }
    }
}
