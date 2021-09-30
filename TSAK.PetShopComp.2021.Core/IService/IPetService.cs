using System.Collections.Generic;
using TSAK.PetShopComp._2021.Filtering;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.IService
{
    public interface IPetService
    {
        List<Pet> GetPets(Filter filter);

        Pet CreatePet(Pet pet);

        Pet UpdatePet(Pet petUpdate);

        Pet FindPetById(int id);

        Pet deletePet(int id);

        //List<Pet> SearchByType(string type);

        //List<Pet> Get5Cheapest();
        
    }
}