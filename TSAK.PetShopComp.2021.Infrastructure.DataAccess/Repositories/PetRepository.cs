using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.EF;
using TSAK.PetShopComp._2021.EF.Entities;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Infrastructure.DataAccess.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopDbContext _ctx;

        public PetRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets
                .Select(pe => new Pet
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Birthdate = pe.Birthdate,
                    SoldDate = pe.SoldDate,
                    Price = pe.Price
                }).ToList();
        }

        public Pet AddPet(Pet pet)
        {
            var beforeSaveEntity = new PetEntity
            {
                Name = pet.Name,
                Price = pet.Price,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate
            };
            var afterSaveEntity =_ctx.Pets.Add(beforeSaveEntity).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name,
                Birthdate = afterSaveEntity.Birthdate,
                SoldDate = afterSaveEntity.SoldDate
            };
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets
                .Select(pe => new Pet
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Price = pe.Price,
                    Birthdate = pe.Birthdate,
                    SoldDate = pe.SoldDate
                    
                }).FirstOrDefault(insurance => insurance.Id== id);
        }

        public Pet Update(Pet petUpdate)
        {
            var beforeSaveEntity = new PetEntity
            {
                Id = petUpdate.Id,
                Name = petUpdate.Name,
                Price = petUpdate.Price,
                Birthdate = petUpdate.Birthdate,
                SoldDate = petUpdate.SoldDate
            };
            var afterSaveEntity =_ctx.Pets.Update(beforeSaveEntity).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name,
                Birthdate = afterSaveEntity.Birthdate,
                SoldDate = afterSaveEntity.SoldDate
            };
        }

        public Pet Delete(int id)
        {
            _ctx.Pets.Remove(new PetEntity {Id = id});
            _ctx.SaveChanges();
            return new Pet
            {
                Id = id
            };
        }
    }
}