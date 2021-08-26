using System;
using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repo;

        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }

        public List<Pet> GetPets()
        {
            var list = _repo.ReadPets();
            var orderedEnumerable = list.OrderBy(pet => pet.Price);
            return orderedEnumerable.ToList();
        }

        public Pet CreatePet(Pet pet)
        {
            return _repo.AddPet(pet);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Price = petUpdate.Price;
            return pet;
        }

        public Pet FindPetById(int id)
        {
            return _repo.ReadById(id);
        }

        public Pet deletePet(int id)
        {
            return _repo.Delete(id);
        }

        public List<Pet> SearchByType(PetType type)
        {
            var list = _repo.ReadPets();
            var searchEnumerable = list.Where(p => p.Type == type);

            return searchEnumerable.ToList();
        }

        public List<Pet> Get5Cheapest()
        {
            var enumerable = GetPets().Take(5);
            return enumerable.ToList();
        }
        
    }
}