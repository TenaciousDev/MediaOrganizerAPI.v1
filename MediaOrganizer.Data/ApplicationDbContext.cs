using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaOrganizer.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<MediaCatalog> MediaCatalogs { get; set; }
    public DbSet<MediaObject> MediaObjects { get; set; }
    public DbSet<MediaType> MediaTypes { get; set; }
  }
}