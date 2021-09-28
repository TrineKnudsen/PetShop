using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShop2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypesController : ControllerBase
    {
        
        private readonly IPetTypeService _petTypeService;

        public PetTypesController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        
        [HttpPost]
        public ActionResult<PetType> Create([FromBody] PetType petType)
        {
            return Created($"https//:localhost/api/petTypes/{petType.Id}",_petTypeService.CreatePetType(petType));
        }

        [HttpGet]
        public ActionResult<List<PetType>> GetAll()
        {
            return Ok(_petTypeService.GetAllPetTypes());
        }

        [HttpPut ("{id}")]
        public ActionResult <PetType>Update(long id, [FromBody] PetType petTypeUpdate)
        {
            if (petTypeUpdate.Id != id)
            {
                return BadRequest("Id does not match");
            }
            return _petTypeService.UpdatePetType(petTypeUpdate);
        }
        
        [HttpDelete]
        public PetType Delete(int id)
        {
            return _petTypeService.DeletePetType(id);
        }
    
    }
}