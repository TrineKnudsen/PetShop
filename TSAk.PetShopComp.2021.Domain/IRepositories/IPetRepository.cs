using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.IRepositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        Pet AddPet(Pet pet);

        Pet ReadById(int id);
        
        Pet Update(Pet petUpdate);

        Pet Delete(int id);
        
    }
}