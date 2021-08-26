using System;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.UI
{
    public class PetMenu 
    {
        private IPetService _service;
        private IPetTypeService _typeService;
        public PetMenu(IPetService service, IPetTypeService typeService)
        {
            _service = service;
            _typeService = typeService;
        }
        
        public void Start()
        {
            ShowWelcomeGreeting();
            StartLoop();
        }
        
        private void StartLoop()
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
                    createPet();
                }

                if (choice == 3)
                {
                    updatePet();
                }

                if (choice == 4)
                {
                    deletePet();
                }

                if (choice == 5)
                {
                    searchByType();
                }

                if (choice == 6)
                {
                    sortByPrice();
                }

                if (choice == 7)
                {
                    GetFiveCheapestPets();
                }
            }
        }

        private void GetFiveCheapestPets()
        {
            throw new NotImplementedException();
        }

        private void sortByPrice()
        {
            throw new NotImplementedException();
        }

        private void searchByType()
        {
            throw new NotImplementedException();
        }

        private void deletePet()
        {
            throw new NotImplementedException();
        }

        private void updatePet()
        {
            throw new NotImplementedException();
        }

        private void createPet()
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
                SoldDate = petSoldDate
            };
            pet = _service.CreatePet(pet);
            Print($"The pet was created! with these information: Id: {pet.Id.Value}, Name:{pet.Name}, Color: {pet.Color}, Type: {pet.Type.Name}, Birthdate: {pet.Birthdate}, Sold date: {pet.SoldDate}, Price: {pet.Price}");
            PrintNewLine();
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
            var pets = _service.GetPets();
            foreach (var pet in pets)
            {
                Print($"Id:{pet.Id.Value}, Name:{pet.Name}, Type:{pet.Type.Name}, Birthdate:{pet.Birthdate}. Sold date:{pet.SoldDate}, Color:{pet.Color}, Price:{pet.Price}");
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
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }

        private void ShowWelcomeGreeting()
                {
                    Print(StringConstants.WelcomeGreeting);
                }
    }
}