using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramsManager.DAL.Database.DBModels
{
    public class OrderPlate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrdenId { get; set; }

        public Guid PlateId { get; set; }

        public Order Order { get; set; }

        public Plate Plate { get; set; }
    }
}
