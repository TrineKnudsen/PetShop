﻿using System.Collections.Generic;
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
            return _repo.ReadPets();
        }

        public Pet CreatePet(Pet pet)
        {
            return _repo.AddPet(pet);
        }
    }
}