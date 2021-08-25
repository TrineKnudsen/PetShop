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
                    Print("Here you have the list");
                }
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