using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.IService
{
    public interface IPetTypeService
    {

        List<PetType> GetAllPetTypes();

        PetType GetById(int id);
        }
        
    }
