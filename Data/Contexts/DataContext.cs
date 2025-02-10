using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }

    //Exempel på hur relationerna ska skrivas,
    //ett projekt måste ha en kund - kunden kan finnas i flera projekt. FK är CustomerId. 
    //Funkar ej, antagligen för att migreringen inte funkar.

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<ProjectEntity>()
    //        .HasOne(x => x.Customer)
    //        .WithMany(x => x.Projects)
    //        .HasForeignKey(x => x.CustomerId);
    //}
}
