using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        IEnumerable<PetType> GetAllPetTypes();
        
        PetType GetById(int id);


        PetType DeletePetType(int id);
        PetType UpdatePetType(PetType typeUpdate);
        PetType CreatePetType(PetType type);
    }
}