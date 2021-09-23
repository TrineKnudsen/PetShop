using System.Collections.Generic;
using System.Security.Cryptography;

namespace TSAK.PetShopComp._2021.EF.Entities
{
    public class InsuranceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<PetEntity> Pets { get; set; }
        
    }
}