namespace SweetSavory.Models
{
  public class FlavorsTreat
    {
        public int FlavorsTreatId { get; set; }
        public int TreatId { get; set; }
        public int FlavorsId { get; set; }
        public Treat Treat { get; set; }
        public Flavors Flavors { get; set; }
    }
}
