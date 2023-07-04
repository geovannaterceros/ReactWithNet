
namespace ProgramsManager.Models.Models.Menu
{
    public class MenuDtoShow
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid RestaurantId { get; set; }
    }
}
