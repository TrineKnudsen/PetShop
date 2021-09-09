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
    [Route("api/owners")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public ActionResult<Owner> Create([FromBody] Owner owner)
        {
            return Created($"https//:localhost/api/owners/{owner.Id}", _ownerService.CreateOwner(owner));
        }

        [HttpGet]
        public ActionResult<Owner> GetAll()
        {
            return Ok(_ownerService.GetOwners());
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater than 0");
            //return _ownerService.FindOwnerById(id);
            return _ownerService.FindOwnerByIdIncludePets(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Update(long id, [FromBody] Owner ownerToUpdate)
        {
            if (ownerToUpdate.Id != id)
            {
                return BadRequest("Id does not match");
            }

            return _ownerService.UpdateOwner(ownerToUpdate);
        }

        [HttpDelete]
        public Owner Delete(int id)
        {
            return _ownerService.DeleteOwner(id);
        }
    }
}