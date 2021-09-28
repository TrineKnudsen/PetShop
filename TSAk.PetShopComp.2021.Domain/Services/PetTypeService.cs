using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            return _repo.GetAllPetTypes().ToList();
        }

        public PetType GetById(int id)
        {
            return _repo.GetById(id);
        }

        public PetType CreatePetType(PetType petType)
        {
            return _repo.CreatePetType(petType);
        }

        public PetType UpdatePetType(PetType petTypeUpdate)
        {
            return _repo.UpdatePetType(petTypeUpdate);
        }

        public PetType DeletePetType(int id)
        {
            return _repo.DeletePetType(id);
        }

        public IEnumerable SearchByType(PetType typeSearch)
        {
            throw new System.NotImplementedException();
        }
    }
}