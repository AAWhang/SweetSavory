using Microsoft.EntityFrameworkCore;

namespace ECSalon.Models
{
  public class ECSalonContext : DbContext
  {
    public virtual DbSet<Stylist> Stylists { get; set; }
    public DbSet<Client> Clients { get; set; }

    public ECSalonContext(DbContextOptions options) : base(options) { }
  }
}
