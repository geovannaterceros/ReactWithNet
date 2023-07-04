using ProgramsManager.Models.Models.Menu;

namespace ProgramsManager.Models.Models.Restaurant
{
    public class RestaurantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public List<MenuDto> Menus { get; set; }

    }
}
