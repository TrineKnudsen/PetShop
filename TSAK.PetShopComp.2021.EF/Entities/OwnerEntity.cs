using System;
using System.Collections.Generic;

namespace TSAK.PetShopComp._2021.EF.Entities
{
    public class OwnerEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }

        public string Email { get; set; }

        public List<PetEntity> Pets { get; set; }
        
    }
}