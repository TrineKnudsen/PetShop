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
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Insurance> ReadById(int id)
        {
            try
            {
                if (id < 1) return BadRequest("Id must be greater than 0");
                return Ok(_insuranceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Fuck");
            }
            
            
        }
        
        [HttpPost]
        public ActionResult<Insurance> Create([FromBody] Insurance insurance)
        {
            try
            {
                return Ok(Created($"https//:localhost/api/owners/{insurance.Id}", _insuranceService.Create(insurance)));
            }
            catch (Exception e)
            {
                 return StatusCode(500, "Fuck");
            }
            
        } 
        
        [HttpGet]
        public ActionResult<List<Insurance>> GetAll()
        {
            try
            {
                return Ok(_insuranceService.ReadAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Fuck");
            }
            
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Insurance> Delete(int id)
        {
            try
            {
                return Ok(_insuranceService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Fuck");
            }
            
        }
        
        [HttpPut("{id}")]
        public ActionResult<Insurance> Update(long id, [FromBody] Insurance insurance)
        {
            try
            {
                if (insurance.Id != id)
                {
                    return BadRequest("Id does not match");
                }

                return Ok(_insuranceService.Update(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Fuck");
            }
            
        }
    } 
}