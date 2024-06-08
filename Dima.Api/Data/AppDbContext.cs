using System.Reflection;
using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  //public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
  
  
  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<Transation> Transations { get; set; }= null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}