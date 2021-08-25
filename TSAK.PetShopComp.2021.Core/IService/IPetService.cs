using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.IService
{
    public interface IPetService
    {
        List<Pet> GetPets();
    }
}