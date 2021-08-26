using System.Collections.Generic;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Infrastructure.DataAccess.Repositories
{
    public class PetTypeRepositoryInMemory : IPetTypeRepository
    {
        private static List<PetType> _petTypeTable = new List<PetType>();

        public PetTypeRepositoryInMemory()
        {
            PetType alpaca = new PetType {Id = 1, Name = "Alpaca"};
            PetType cat = new PetType {Id = 2, Name = "Cat"};
            PetType dog = new PetType {Id = 3, Name = "Dog"};
            PetType snake = new PetType {Id = 4, Name = "Snake"};
            _petTypeTable.AddRange(new List<PetType>{alpaca, cat, dog, snake});
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypeTable;
        }

        public PetType GetById(int id)
        {
            foreach (PetType petType in _petTypeTable)
            {
                if (petType.Id == id)
                {
                    return petType;
                }
            }

            return null;
        }
    }
}