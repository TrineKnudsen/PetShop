namespace TSAK.PetShopComp._2021.UI
{
    public class StringConstants
    {
        public const string WelcomeGreeting = "Welcome to the Petshop";
        public const string PleaseSelectMain = "Please select one of the Items below to continue";
        
        //MainMenu
        public const string PetMenu = "Select 1 to go to the pet menu";
        public const string OwnerMenu = "Select 2 to go to the owner menu";
        
        //PetMenu
        public const string ViewAllPets = "Select 1 to view all pets in the Pet shop";
        public const string CreatePet = "Select 2 to create a new pet";
        public const string UpdatePet = "Select 3 to edit pet name and price";
        public const string PetDelete = "Select 4 to delete a pet";
        public const string SearchType = "Select 5 to search for a type";
        public const string Get5Cheapest = "Select 6 to see the 5 cheapest pets";
        
        //Create Pet
        public const string CreatePetGreeting = "Welcome to the pet factory, please follow the instructions to create your new pet";
        public const string PetName = "Please enter a name for the pet";
        public const string PetColor = "Please enter the color of the pet";
        public const string PetBirthdate = "Please enter birthday of the pet (DD-MM-YYYY)";
        public const string PetSoldDate = "Please enter sold date of the pet (DD-MM-YYYY)";
        public const string PetPrice = "Please enter the price of the pet";
        //Update pet
        public const string TypeId = "Please type in id of the pet you want to edit ";
        public const string NewName = "Please type in the new name for the pet";
        public const string NewPrice = "Please type in the new price for the pet";

        //Delete pet
        public const string PetToDelete = "Please select the id of the pet you want to delete";

        //Sort by type
        public static string WriteType = "Please enter the pet type you want to see";


        public const string UseNumberValue = "Whoopsie, that wasn't a number, please try again";

        public const string CheapestPets = "This is the 5 cheapest pets available at the moment";
        
        //OwnerMenu
        public const string CreateOwner = "Select 1 to create a new owmer";
        public const string ViewOwners = "Select 2 to view all owners";
        public const string UpdateOwner = "Select 3 update owner";
        public const string DeleteOwner = "Select 4 to delete an owner";
        
        
        //UpdateOwner
        public const string NewOwnerEmail ="Please enter the new email of the owner"; 
        public const string NewOwnerAddress ="Please enter the new address of the owner"; 
        public const string TypeIdOwner ="Please type in the id of the owner you want to update";
        //DeleteOwner
        public const string OwnerToDelete = "Please select the id of the owner you want to delete";
        //CreateOwner
        public const string CreateOwnerGreeting = "Welcome to the owner factory, please follow the instructions to create a new owner";
        public const string OwnerName = "Please type the name of the owner";
        public const string OwmerEmail = "Please type the Email of the owner";
        public const string OwnerAddress = "Please type the address of the owner";
    }
}