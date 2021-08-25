using System;
using System.Collections.Generic;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Infrastructure.DataAccess.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int nextId = 1;

        public PetRepositoryInMemory()
        {
            PetType alpaca = new PetType {Id = 1, Name = "Alpaca"};
            PetType cat = new PetType {Id = 2, Name = "Cat"};
            PetType dog = new PetType {Id = 3, Name = "Dog"};
            PetType snake = new PetType {Id = 4, Name = "Snake"};
            
            Pet pet1 = new Pet
            {
                Name = "Carla", Color = "Brown", Birthdate = DateTime.Now,
                SoldDate = DateTime.Now, Type = alpaca, Price = 500.55
            };
            
            Pet pet2 = new Pet
            {
                Name = "Whiskers", Color = "Black", Birthdate = DateTime.Now,
                SoldDate = DateTime.Now, Type = cat, Price = 200
            };
            
            Pet pet3 = new Pet
            {
                Name = "Pluto", Color = "Orange", Birthdate = DateTime.Now,
                SoldDate = DateTime.Now, Type = dog, Price = 300
            }; 
            
            Pet pet4 = new Pet
            {
                Name = "Nagini", Color = "Green", Birthdate = DateTime.Now,
                SoldDate = DateTime.Now, Type = snake, Price = 1_000
            };
            
            AddPet(pet1);
            AddPet(pet2);
            AddPet(pet3);
            AddPet(pet4);

        }
        public List<Pet> ReadPets()
        {
            return _petTable;
        } 
        public Pet AddPet(Pet pet)
        {
            pet.Id = nextId;
            _petTable.Add(pet);

            nextId++;
            return pet;
        }

        
    }
}