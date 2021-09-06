using System.Collections;
using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.IService
{
    public interface IOwnerService
    {
        List<Owner> GetOwners();

        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(Owner ownerToUpdate);

        Owner DeleteOwner(int id);
        
        Owner FindOwnerById(int idUpdate);
    }
}