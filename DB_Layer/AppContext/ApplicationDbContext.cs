using DB_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_Layer.AppContext
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<AddressInfo> AUP { get; set; }
        public DbSet<DistModel> RAJ { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<DistModel>()
                .ToTable("raj")
                .HasKey(d => d.pKey);
            modelBuilder.Entity<DistModel>()
                .Property(d => d.pKey)
                .HasColumnName("raj");
            modelBuilder.Entity<DistModel>()
                .Property(d => d.rajName)
                .HasColumnName("nraj");

            modelBuilder.Entity<AddressInfo>()
                .ToTable("aup")
                .HasKey(d => d.Id);

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.Id)
                .HasColumnName("id");

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.IndexA)
                .HasColumnName("postcode");

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.City)
                .HasColumnName("city");

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.NCity)
                .HasColumnName("ncity");

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.Obl)
                .HasColumnName("obl");

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.NObl)
                .HasColumnName("nobl");

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.Raj)
                .HasColumnName("raj");

            modelBuilder.Entity<AddressInfo>()
                .Property(a => a.NRaj)
                .HasColumnName("nraj");
        }
    }
}
