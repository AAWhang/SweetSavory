using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ToDoList.Models
{
    [Table("Items")]
    public class Item
    {
      public Item()
        {
            this.Categories = new HashSet<CategoryItem>();
        }

        [Key]
        public int ItemId { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryItem> Categories { get;}
        // new code
        public virtual ApplicationUser User { get; set; }
    }
}
