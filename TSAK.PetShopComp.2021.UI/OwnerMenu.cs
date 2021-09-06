using System;
using System.Collections.Generic;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.UI
{
    public class OwnerMenu
    {
        private static List<Owner> Owners;
        private IOwnerService _serviceOwner;

        public OwnerMenu(IOwnerService serviceOwner)
        {
            _serviceOwner = serviceOwner;
        }
        public void StartOwnerMenu()
        {
            StartOwnerLoop();
        }

        private void StartOwnerLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                   CreateOwner(); 
                }

                if (choice == 2)
                {
                    ReadAllOwners();
                }

                if (choice == 3)
                {
                    UpdateOwner();
                }

                if (choice == 4)
                {
                    DeleteOwner();
                }

            }
            
        }

        private void DeleteOwner()
        {
            Print(StringConstants.OwnerToDelete);
            ReadAllOwners();

            var idDelete = int.Parse(Console.ReadLine());
            if (idDelete !=null)
            {
                _serviceOwner.DeleteOwner(idDelete);
                Print($"Owner with this id: {idDelete}, was deleted successfully from the list");
            }
        }

        private void UpdateOwner()
        {
            Print(StringConstants.TypeIdOwner);
            ReadAllOwners();
            int idUpdate = int.Parse(Console.ReadLine());
            var ownerToUpdate = _serviceOwner.FindOwnerById(idUpdate);
            
            Print(StringConstants.NewOwnerAddress);
            var newAddress = Console.ReadLine();
            
            Print(StringConstants.NewOwnerEmail);
            var newEmail = Console.ReadLine();

            _serviceOwner.UpdateOwner(new Owner()
                {
                    Id = ownerToUpdate.Id,
                    Name = ownerToUpdate.Name,
                    Address = newAddress,
                    Email = newEmail
                }
            );
            Print($"Owner was updated! New address: {ownerToUpdate.Address} and New email: {ownerToUpdate.Email}");
        }

        private void ReadAllOwners()
        {
            Print("Here is a list of all current owners");
            foreach (var owner in _serviceOwner.GetOwners())
            {
                Print($"Id: {owner.Id}, Name: {owner.Name}, Address: {owner.Address}, Email: {owner.Email}");
            }
        }

        private void CreateOwner()
        {
            PrintNewLine();
            Print(StringConstants.CreateOwnerGreeting);
            Print(StringConstants.OwnerName);
            var ownerName = Console.ReadLine();
            
            Print(StringConstants.OwmerEmail);
            var ownerEmail = Console.ReadLine();
            
            Print(StringConstants.OwnerAddress);
            var ownerAddress = Console.ReadLine();

            var owner = new Owner
            {
                Name = ownerName,
                Email = ownerEmail,
                Address = ownerAddress
            };

            owner = _serviceOwner.CreateOwner(owner);
            Print($"The owner was created with these information: Id: {owner.Id}, Name: {owner.Name}, Address: {owner.Address}, Email: {owner.Email}");
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
            Print(StringConstants.CreateOwner);
            Print(StringConstants.ViewOwners);
            Print(StringConstants.UpdateOwner);
            Print(StringConstants.DeleteOwner);
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }
    }
    }
