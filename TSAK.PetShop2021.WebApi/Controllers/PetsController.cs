using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;


namespace TSAK.PetShop2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        
        [HttpPost]
        public Pet Create(Pet pet)
        {
            return _petService.CreatePet(pet);
        }

        [HttpGet]
        public List<Pet> GetAll()
        {
            return _petService.GetPets();
        }
    }
}