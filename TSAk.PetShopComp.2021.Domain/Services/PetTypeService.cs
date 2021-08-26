using System.Collections;
using System.Collections.Generic;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {

        private IPetTypeRepository _repo;

        public PetTypeService(IPetTypeRepository repo)
        {
            _repo = repo;
        }
        public List<PetType> GetAllPetTypes()
        {
            return _repo.GetAllPetTypes();
        }

        public PetType GetById(int id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable SearchByType(PetType typeSearch)
        {
            throw new System.NotImplementedException();
        }
    }
}