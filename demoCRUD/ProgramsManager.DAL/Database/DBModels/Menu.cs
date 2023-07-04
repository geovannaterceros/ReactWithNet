using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramsManager.DAL.Database.DBModels
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

 
        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public List<Plate> Plates { get; set; }

    }
}
