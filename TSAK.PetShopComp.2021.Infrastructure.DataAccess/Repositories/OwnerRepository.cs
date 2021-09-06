using System.Collections.Generic;
using System.Data.Common;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Infrastructure.DataAccess.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private static List<Owner> _ownersTable;
        private static int _idOwner = 1;

        public OwnerRepository()
        {
            Owner owner = new Owner
            {
                Name = "Carl", Address = "Carlsvej 3", Email = "carlsemail@email.com"
            };
            Owner owner1 = new Owner
            {
                Name = "Jan", Address = "Jansvej 3", Email = "jansemail@email.com"
            };
            CreateOwner(owner);
            CreateOwner(owner1);

        }
        public IEnumerable<Owner> ReadAllOwners()
        {
            return _ownersTable;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = _idOwner++;
            _ownersTable.Add(owner);
            return owner;
        }

        public Owner ReadById(int id)
        {
            foreach (var owner in _ownersTable)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }

            return null;
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var owner = ReadById(ownerToUpdate.Id);
            if (owner !=null)
            {
                owner.Name = ownerToUpdate.Name;
                owner.Address = ownerToUpdate.Address;
                owner.Email = ownerToUpdate.Email;
                return owner;

            }

            return null;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerFound = ReadById(id);
            if (ownerFound != null)
            {
                _ownersTable.Remove(ownerFound);
                return ownerFound;
            }

            return null;
        }
    }
}