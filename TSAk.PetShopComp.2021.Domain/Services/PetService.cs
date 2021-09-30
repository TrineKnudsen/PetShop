using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Filtering;
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

        public List<Pet> GetPets(Filter filter)
        {
            if (filter == null || filter.Limit <1 || filter.Limit >100)
            {
                throw new ArgumentException("Filter limit must be between 1 to 100");
            }

            var totalCount = TotalCount();
            var maxPageCount = Math.Ceiling((double) totalCount / filter.Limit);
            if (filter.Page <1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException($"Filter must be between 1 and {maxPageCount}");
            }

            return _repo.ReadPets(filter).ToList();
        }

        private double TotalCount()
        {
            return _repo.TotalCount();
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

        /*public List<Pet> SearchByType(string type, Filter filter)
        {
            var list = _repo.ReadPets(filter);
            var searchEnumerable = list.Where(p => p.Type.Name == type);

            return searchEnumerable.ToList();
        }

        public List<Pet> Get5Cheapest()
        {
            var enumerable = GetPets().Take(5);
            return enumerable.ToList();
        }*/
        
    }
}