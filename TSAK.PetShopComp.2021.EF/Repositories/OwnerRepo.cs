using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.EF.Entities;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.EF.Repositories
{
    public class OwnerRepo : IOwnerRepository
    {
        private readonly PetShopDbContext _ctx;

        public OwnerRepo(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Owner> ReadAllOwners()
        {
            return _ctx.Owners
                .Select(oe => new Owner
                {
                    Id = oe.Id,
                    Name = oe.Name,
                    Email = oe.Email,
                    Address = oe.Address
                }).ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            var beforeSaveEntity = new OwnerEntity
            {
                Name = owner.Name,
                Address = owner.Address,
                Email = owner.Email
            };
            var afterSaveEntity = _ctx.Owners.Add(beforeSaveEntity).Entity;
            _ctx.SaveChanges();
            return new Owner
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name,
                Address = afterSaveEntity.Address,
                Email = afterSaveEntity.Email
            };
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var beforeSaveEntity = new OwnerEntity
            {
                Name = ownerToUpdate.Name,
                Address = ownerToUpdate.Address,
                Email = ownerToUpdate.Email
            };
            var afterSaveEntity = _ctx.Owners.Update(beforeSaveEntity).Entity;
            _ctx.SaveChanges();
            return new Owner
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name,
                Address = afterSaveEntity.Address,
                Email = afterSaveEntity.Email
            };
        }

        public Owner DeleteOwner(int id)
        {
            _ctx.Owners.Remove(new OwnerEntity {Id = id});
            _ctx.SaveChanges();
            return new Owner
            {
                Id = id
            };
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners
                .Select(oe => new Owner
                {
                    Id = oe.Id,
                    Name = oe.Name,
                    Address = oe.Address,
                    Email = oe.Email
                }).FirstOrDefault(insurance => insurance.Id == id);
        }
    }
}