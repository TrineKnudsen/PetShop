using System;
using TSAK.PetShopComp._2021.IService;
namespace TSAK.PetShopComp._2021.UI

{
    public class StartMenu
    {
        private IPetService _service;
        private IPetTypeService _typeService;
        private IOwnerService _serviceOwner;

        public StartMenu(IPetService service, IPetTypeService typeService, IOwnerService ownerService)
        {
            _service = service;
            _typeService = typeService;
            _serviceOwner = ownerService;
        }
        public void Start()
        {
            ShowWelcomeGreeting();
            StartMainLoop();
        }

        private void StartMainLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    GoToPetMenu();
                }

                if (choice == 2)
                {
                    GoToOwnerMenu();
                }
            }
        }

        private void GoToOwnerMenu()
        {
            OwnerMenu ownerMenu = new OwnerMenu(_serviceOwner);
            ownerMenu.StartOwnerMenu();
        }

        private void GoToPetMenu()
        {
            PetMenu petMenu = new PetMenu(_service, _typeService);
            petMenu.StartPetMenu();

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
            Print(StringConstants.PetMenu);
            Print(StringConstants.OwnerMenu);
        }

        private void ShowWelcomeGreeting()
        {
            Print(StringConstants.WelcomeGreeting);
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }
    }

    
    }