using System.Collections.Generic;

namespace TSAK.PetShopComp._2021.EF.Entities
{
    public class PetTypeEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<PetEntity> Pets { get; set; }
        
    }
}