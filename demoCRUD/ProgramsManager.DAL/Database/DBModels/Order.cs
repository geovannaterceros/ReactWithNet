

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramsManager.DAL.Database.DBModels
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]    
        public int NumberOrder { get; set; }

        public List<OrderPlate> OrdensPlates { get; set; }

        public List<Plate> Plates { get; set; }
    }
}
