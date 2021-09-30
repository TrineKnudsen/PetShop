using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TSAK.PetShopComp._2021.Filtering;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;


namespace TSAK.PetShop2021.WebApi.Controllers
{
    [Route("api/pets")]
    [ApiController]
    
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        
        [HttpPost]
        public ActionResult<Pet> Create([FromBody] Pet pet)
        {
            return Created($"https//:localhost/api/pets/{pet.Id}",_petService.CreatePet(pet));
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAll(Filter filter)
        {
            return Ok(_petService.GetPets(filter));
        }

        [HttpPut ("{id}")]
        public ActionResult <Pet>Update(long id, [FromBody] Pet petToUpdate)
        {
            if (petToUpdate.Id != id)
            {
                return BadRequest("Id does not match");
            }
            return _petService.UpdatePet(petToUpdate);
        }
        
        [HttpDelete]
        public Pet Delete(int id)
        {
            return _petService.deletePet(id);
        }
    }
}