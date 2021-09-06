using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadAllOwners();

        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(Owner ownerToUpdate);

        Owner DeleteOwner(int id);

        Owner ReadById(int id);
    }
}