using System;
using System.Collections.Generic;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.UI
{
    public class PetMenu 
    {
        private static List<Pet> pets;
        private IPetService _service;
        private IPetTypeService _typeService;
        public PetMenu(IPetService service, IPetTypeService typeService)
        {
            _service = service;
            _typeService = typeService;
        }
        
        public void StartPetMenu()
        {
            StartPetLoop();
        }
        
        private void StartPetLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    ReadAll();
                }

                if (choice == 2)
                {
                    CreatePet();
                }

                if (choice == 3)
                {
                    UpdatePet();
                }

                if (choice == 4)
                {
                    DeletePet();
                }

                if (choice == 5)
                {
                    SearchByType();
                }

                if (choice == 6)
                {
                    Get5Cheapest();
                }
            }
        }

        private void Get5Cheapest()
        {
            Print(StringConstants.CheapestPets);
            foreach (var pet in _service.Get5Cheapest())
            {
                Print($"Price: {pet.Price}, Type: {pet.Type.Name}, Name: {pet.Name}, Color: {pet.Color}, Birthdate: {pet.Birthdate}");
            }
        }
        

        private void SearchByType()
        {
            Print(StringConstants.WriteType);
            var typeSearch = Console.ReadLine();

            foreach (var pet in _service.SearchByType(typeSearch))
            {
                Print($"Id: {pet.Id}, Name: {pet.Name}, Color: {pet.Color}, Birthday: {pet.Birthdate}, Sold: {pet.SoldDate}, Price: {pet.Price} ");
            }
        }

        private void DeletePet()
        {
            Print(StringConstants.PetToDelete);
            ReadAll();
            var idDelete = int.Parse(Console.ReadLine());
            if (idDelete != null)
            {
                _service.deletePet(idDelete);
                Print($"Pet with this id: {idDelete}, was successfully deleted from the list");
            }
           
        }

        private void UpdatePet()
        {
            Print(StringConstants.TypeId);
            ReadAll();
            int idUpdate = int.Parse(Console.ReadLine());
            var petUpdate = _service.FindPetById(idUpdate);
            
            Print(StringConstants.NewName);
            var newName = Console.ReadLine();
            
            Print(StringConstants.NewPrice);
            var newPrice = double.Parse(Console.ReadLine());

            _service.UpdatePet(new Pet()
                {
                Id = petUpdate.Id,
                Name = newName,
                Price = newPrice,
                Color = petUpdate.Color,
                Birthdate = petUpdate.Birthdate,
                SoldDate = petUpdate.SoldDate,
                Type = petUpdate.Type
                }
            );
            Print($"Pet was updated! New name: {petUpdate.Name} and New price: {petUpdate.Price}");
        }

        private void CreatePet()
        {
            PrintNewLine();
            Print(StringConstants.CreatePetGreeting);
            Print(StringConstants.PetName);
            var petName = Console.ReadLine();
            
            Print(StringConstants.PetColor);
            var petColor = Console.ReadLine();
            
            Print(StringConstants.PetBirthdate);
            var petBirth = Console.ReadLine();
            DateTime petBirthDate = DateTime.Parse(petBirth);
            
            Print(StringConstants.PetSoldDate);
            var petSold = Console.ReadLine();
            DateTime petSoldDate = DateTime.Parse(petSold);
            
            Print(StringConstants.PetPrice);
            string petPrice = Console.ReadLine();
            double petPriceParse = double.Parse(petPrice);
            
            
            Print("Please select a pet type Id");
            seeAllPetTypes();
            var petType = Console.ReadLine();
            int selection;
            while (!int.TryParse(petType, out selection))
            {
                Print("whoopsie, you didn't type in a number! Try again!");
                petType = Console.ReadLine();
            }

            while (_typeService.GetById(selection) == null)
            {
                Print("The Id you selected does not exist! Try again!");
                Console.ReadLine();
            }

            PetType pt = _typeService.GetById(selection);

            var pet = new Pet
            {
                Name = petName,
                Type = pt,
                Price = petPriceParse,
                Birthdate = petBirthDate,
                SoldDate = petSoldDate,
                Color = petColor
            };
            pet = _service.CreatePet(pet);
            Print($"The pet was created! with these information: Id: {pet.Id}, Name:{pet.Name}, Color: {pet.Color}, Type: {pet.Type.Name}, Birthdate: {pet.Birthdate}, Sold date: {pet.SoldDate}, Price: {pet.Price}");
            PrintNewLine();
        }

        private static Pet FindPetById()
        {
            Console.WriteLine("Insert pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            foreach (var pet in pets)
            {
                if (pet.Id == id)
                {
                   return pet;
                }
            }

            return null;
        }

        private void seeAllPetTypes()
        {
            var petTypes = _typeService.GetAllPetTypes();
            foreach (PetType p in petTypes)
            {
                Print($"Id: {p.Id.Value} - {p.Name}");
            }
        }

        private void ReadAll()
        {
            Print("Here are all pets we have");
            foreach (var pet in _service.GetPets())
            {
                Print($"Id:{pet.Id}, Name:{pet.Name}, Type:{pet.Type.Name}, Birthdate:{pet.Birthdate}. Sold date:{pet.SoldDate}, Color:{pet.Color}, Price:{pet.Price}");
            }
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            PrintNewLine();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }

            return -1;
        }

        private void PrintNewLine()
        {
            Console.WriteLine("");
        }

        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstants.PleaseSelectMain);
            Print(StringConstants.ViewAllPets);
            Print(StringConstants.CreatePet);
            Print(StringConstants.UpdatePet);
            Print(StringConstants.PetDelete);
            Print(StringConstants.SearchType);
            Print(StringConstants.Get5Cheapest);
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }
        
    }
}