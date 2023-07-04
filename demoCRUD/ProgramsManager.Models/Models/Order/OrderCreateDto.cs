
namespace ProgramsManager.Models.Models.Order
{
    public class OrderCreateDto
    {
        public int NumberOrder { get; set; }

        public List<Guid> PlatesIds { get; set; }
    }
}
