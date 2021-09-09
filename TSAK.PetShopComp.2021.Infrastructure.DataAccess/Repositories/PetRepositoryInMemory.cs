using System;
using System.Collections.Generic;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Infrastructure.DataAccess.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _id = 1;

        public PetRepositoryInMemory()
        {
            PetType alpaca = new PetType {Id = 1, Name = "Alpaca"};
            PetType cat = new PetType {Id = 2, Name = "Cat"};
            PetType dog = new PetType {Id = 3, Name = "Dog"}; 
            PetType snake = new PetType {Id = 4, Name = "Snake"}; 
            
            if (FakeDB.pets.Count > 0) return;
            var pet1 = new Pet()
            {
                Id = FakeDB._id++,
                Price = 200,
                Type = alpaca,
                Birthdate = DateTime.Now.AddDays(200),
                SoldDate = DateTime.Now.AddDays(150),
                Name = "Carla",
                Color = "Brown",
                Owner = new Owner(){Id = 1}
            };
            FakeDB.pets.Add(pet1);
            
            var pet2 = new Pet()
            {
                Id = FakeDB._id++,
                Price = 150,
                Type = cat,
                Birthdate = DateTime.Now.AddDays(100),
                SoldDate = DateTime.Now.AddDays(20),
                Name = "Whiskers",
                Color = "Black",
                Owner = new Owner(){Id = 2}
            };
            FakeDB.pets.Add(pet2);
            
            var pet3 = new Pet()
            {
                Id = FakeDB._id++,
                Price = 300,
                Type = dog,
                Birthdate = DateTime.Now.AddDays(365),
                SoldDate = DateTime.Now.AddDays(260),
                Name = "Pluto",
                Color = "Orange",
                Owner = new Owner(){Id = 2}
            };
            FakeDB.pets.Add(pet3);
            
            var pet4 = new Pet()
            {
                Id = FakeDB._id++,
                Price = 1000,
                Type = snake,
                Birthdate = DateTime.Now.AddDays(450),
                SoldDate = DateTime.Now.AddDays(100),
                Name = "Nagini",
                Color = "Green",
                Owner = new Owner(){Id = 1}
            };
            FakeDB.pets.Add(pet4);
            
            var pet5 = new Pet()
            {
                Id = FakeDB._id++,
                Price = 1200,
                Type = snake,
                Birthdate = DateTime.Now.AddDays(230),
                SoldDate = DateTime.Now.AddDays(220),
                Name = "Perry",
                Color = "Blue",
                Owner = new Owner(){Id = 1}
            };
            FakeDB.pets.Add(pet5);
            
            var pet6 = new Pet()
            {
                Id = FakeDB._id++,
                Price = 350,
                Type = cat,
                Birthdate = DateTime.Now.AddDays(150),
                SoldDate = DateTime.Now.AddDays(99),
                Name = "Tom",
                Color = "Grey",
                Owner = new Owner(){Id = 2}
            };
            FakeDB.pets.Add(pet6);
            
        }
        public IEnumerable<Pet> ReadPets()
        {
            return _petTable;
        } 
        public Pet AddPet(Pet pet)
        {
            pet.Id = FakeDB._id++;
            FakeDB.pets.Add(pet);
            return pet;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _petTable)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            
            return null;
        }
        
        public Pet Update(Pet petUpdate)
        {
            var pet = ReadById(petUpdate.Id);
            if (pet != null)
            {
                pet.Name = petUpdate.Name;
                pet.Price = petUpdate.Price;
                return pet;
            }

            return null;
        }

        public Pet Delete(int id)
        {
            var petFound = ReadById(id);
            if (petFound != null)
            {
                _petTable.Remove(petFound);
                return petFound;
            }

            return null;
        } 
    }
}