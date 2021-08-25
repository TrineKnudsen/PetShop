using System;
using TSAK.PetShopComp._2021.IService;

namespace TSAK.PetShopComp._2021.UI
{
    public class PetMenu 
    {
        private IPetService _service;
        public PetMenu(IPetService service)
        {
            _service = service;
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
            }
        }

        private void createPet()
        {
            Print("Welcome to the pet factory, please follow the instructions to create your new pet");
            
            Print("Please write the name for the pet");
            string petName = Console.ReadLine();
            PrintNewLine();
            
            Print("Please enter the color of the pet");
            string petColor = Console.ReadLine();
            PrintNewLine();
            
            
        }

        private void ReadAll()
        {
            Print("Here are all pets we have");
            var pets = _service.GetPets();
            foreach (var pet in pets)
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