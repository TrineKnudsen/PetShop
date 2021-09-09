
using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        readonly IPetRepository _petRepo;

        public OwnerService(IOwnerRepository ownerRepo, IPetRepository petRepository)
        {
            _ownerRepo = ownerRepo;
            _petRepo = petRepository;
        }
        public List<Owner> GetOwners()
        {
            var list = _ownerRepo.ReadAllOwners();
            return list.ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var owner = FindOwnerById(ownerToUpdate.Id);
            if (owner != null)
            {
              owner.Name = ownerToUpdate.Name;
              owner.Address = ownerToUpdate.Address;
              owner.Email = ownerToUpdate.Email;  
            }
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.DeleteOwner(id);
        }

        public Owner FindOwnerById(int idUpdate)
        {
            return _ownerRepo.ReadById(idUpdate);
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepo.ReadById(id);
            owner.Pets = _petRepo.ReadPets()
                .Where(pet => pet.Owner.Id == owner.Id).ToList();
            return owner;
        }
    }
}