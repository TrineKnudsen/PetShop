using Microsoft.EntityFrameworkCore;
using TSAK.PetShopComp._2021.EF.Entities;

namespace TSAK.PetShopComp._2021.EF
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 1, Name = "SafeScuff", Price = 22});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 2, Name = "NextName", Price = 220});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 3, Name = "Scuff", Price = 2200});
        }

        public DbSet<InsuranceEntity> Insurances { get; set; }
    }
}