using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramsManager.Models.Models.Plate
{
    public class PlateDtoCreated
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateActivity { get; set; }

        public bool Offer { get; set; }

        public string UIDUser { get; set; }

        public Guid MenuId { get; set; }
    }
}
