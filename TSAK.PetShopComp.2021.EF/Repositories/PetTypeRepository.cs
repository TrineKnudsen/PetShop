using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.EF.Entities;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.EF.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetShopDbContext _ctx;

        public PetTypeRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _ctx.PetTypes
                .Select(pt => new PetType
                {
                    Id = pt.Id,
                    Name = pt.Name
                }).ToList();
        }

        public PetType GetById(int id)
        {
            return _ctx.PetTypes
                .Select(pt => new PetType
                {
                    Id = pt.Id,
                    Name = pt.Name
                }).FirstOrDefault( petType => petType.Id == id);
        }

        public PetType DeletePetType(int id)
        {
            _ctx.PetTypes.Remove(new PetTypeEntity {Id = id});
            _ctx.SaveChanges();
            return new PetType
            {
                Id = id
            };
        }

        public PetType UpdatePetType(PetType typeUpdate)
        {
            var beforeSaveEntety = new PetTypeEntity
            {
                Id = typeUpdate.Id,
                Name = typeUpdate.Name
            };
            var afterSaveEntity = _ctx.PetTypes.Update(beforeSaveEntety).Entity;
            _ctx.SaveChanges();
            return new PetType
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name
            };
        }

        public PetType CreatePetType(PetType type)
        {
            var beforeSaveEntety = new PetTypeEntity
            {
                Id = type.Id,
                Name = type.Name
            };
            var afterSaveEntity = _ctx.PetTypes.Add(beforeSaveEntety).Entity;
            _ctx.SaveChanges();
            return new PetType
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name
            };
        }
    }
}