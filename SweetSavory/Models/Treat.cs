using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SweetSavory.Models
{
    [Table("Treats")]
    public class Treat
    {
      public Treat()
        {
            this.Flavors = new HashSet<FlavorsTreat>();
        }

        [Key]
        public int TreatId { get; set; }
        public string Description { get; set; }
        public ICollection<FlavorsTreat> Flavors { get;}
        // new code
        public virtual ApplicationUser User { get; set; }
    }
}
