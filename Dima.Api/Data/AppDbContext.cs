using System.Reflection;
using Dima.Api.Mappings;
using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Data;

public class AppDbContext:DbContext
{
  public DbSet<Category> Categories { get; set; } = null!;

  public DbSet<Transation> Transations { get; set; }= null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}