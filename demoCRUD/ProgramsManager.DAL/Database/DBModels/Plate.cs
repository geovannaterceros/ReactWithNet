using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramsManager.DAL.Database.DBModels
{
    public class Plate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateActivity { get; set; }

        [Required]
        public bool Offer { get; set; }

        [Required]
        public string UIDUser { get; set; }

        public Guid MenuId { get; set; }

        public Menu Menu { get; set; }

        public List<OrderPlate> OrdersPlates { get; set; }
    }
}
