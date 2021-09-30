using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.EF.Entities;
using TSAK.PetShopComp._2021.Filtering;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.EF.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopDbContext _ctx;

        public PetRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            var selectQuery = _ctx.Pets
                .Select(pe => new Pet
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Birthdate = pe.Birthdate,
                    SoldDate = pe.SoldDate,
                    Price = pe.Price
                });
            if (filter.OrderDir.ToLower().Equals("asc"))
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderBy(p => p.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderBy(p => p.Id);
                        break;
                    case "price":
                        selectQuery = selectQuery.OrderBy(p => p.Price);
                        break;
                    
                }
            }
            else
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderByDescending(p => p.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderByDescending(p => p.Id);
                        break;
                    case "price":
                        selectQuery = selectQuery.OrderByDescending(p => p.Price);
                        break;
                }
            }

            selectQuery = selectQuery.Where(p => p.Name.ToLower().StartsWith(filter.Search.ToLower()));
            var query = selectQuery
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);

            return query.ToList();

        }

        public int TotalCount()
        {
            return _ctx.Pets.Count();
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