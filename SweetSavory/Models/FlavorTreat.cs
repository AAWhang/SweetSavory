namespace SweetSavory.Models
{
  public class FlavorsTreat
    {
        public int FlavorsTreatId { get; set; }
        public int TreatId { get; set; }
        public int FlavorsId { get; set; }
        public virtual Treat Treat { get; set; }
        public virtual Flavors Flavors { get; set; }
    }
}
