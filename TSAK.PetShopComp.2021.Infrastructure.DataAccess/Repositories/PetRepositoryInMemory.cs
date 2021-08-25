using System.Collections.Generic;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Infrastructure.DataAccess.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        public List<Pet> ReadPets()
        {
            throw new System.NotImplementedException();
        }
    }
}