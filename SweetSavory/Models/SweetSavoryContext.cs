using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SweetSavory.Models
{
  public class SweetSavoryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Flavors> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<FlavorsTreat> FlavorsTreat { get; set; }

    public SweetSavoryContext(DbContextOptions options) : base(options) { }
  }
}
