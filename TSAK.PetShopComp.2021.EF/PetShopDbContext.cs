using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TSAK.PetShopComp._2021.EF.Entities;

namespace TSAK.PetShopComp._2021.EF
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* var random = new Random();
            var names = new List<string> {"Karlo", "Børge", "Ged"};
            var price = new List<double> {255, 400, 500};
            for (var i = 1; i < 1000; i++)
            {
                var petName = $"{names[random.Next(0, 3)]} {i}";
                var pricing = price[random.Next(0, 3)];
                modelBuilder.Entity<PetEntity>()
                    .HasData(new PetEntity
                    {
                        Id = i,
                        Name = petName,
                        Price = pricing
                    });
            }
        }*/
        modelBuilder.Entity<PetEntity>()
            .HasOne(petEntity => petEntity.Insurance)
            .WithMany(insuranceEntity => insuranceEntity.Pets);

        modelBuilder.Entity<PetEntity>()
            .HasOne(petEntity => petEntity.Owner)
            .WithMany(ownerEntity => ownerEntity.Pets);


        modelBuilder.Entity<InsuranceEntity>()
            .HasData(new InsuranceEntity {Id = 1, Name = "SafeScuff", Price = 22});
        modelBuilder.Entity<InsuranceEntity>()
            .HasData(new InsuranceEntity {Id = 2, Name = "NextName", Price = 220});
        modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 3, Name = "Scuff", Price = 2200});
        
        modelBuilder.Entity<PetEntity>().HasData(new PetEntity {Id = 1, Birthdate = DateTime.Now, Name = "Bo", Color = "Sort", Price = 47.5, SoldDate = DateTime.Now, OwnerId = 1, PetTypeId = 1, InsuranceId = 3});
        modelBuilder.Entity<PetEntity>().HasData(new PetEntity {Id = 2, Birthdate = DateTime.Now, Name = "Bent", Color = "Brun", Price = 100, SoldDate = DateTime.Now, OwnerId = 1, PetTypeId = 3, InsuranceId = 2});
        modelBuilder.Entity<PetEntity>().HasData(new PetEntity {Id = 3, Birthdate = DateTime.Now, Name = "Hans", Color = "Lilla", Price = 147.5, SoldDate = DateTime.Now, OwnerId = 2, PetTypeId = 4, InsuranceId = 1});
        
        modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 1, Name = "Alapaca"});
        modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 2, Name = "Cat"});
        modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 3, Name = "Dog"});
        modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 4, Name = "Snake"});

        modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {Id = 1, Address = "Den vej der 3", Email = "Denbedste@email.dk", Name = "Karl"}); 
        modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {Id = 2, Address = "Den vej der 7", Email = "Dendårligste@email.dk", Name = "Jens"});
    }

        public DbSet<InsuranceEntity> Insurances { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
    
        }
    }
