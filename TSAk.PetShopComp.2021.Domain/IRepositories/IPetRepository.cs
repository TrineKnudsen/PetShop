using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> ReadPets();
    }
}