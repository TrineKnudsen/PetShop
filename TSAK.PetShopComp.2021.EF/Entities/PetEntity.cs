using System;

namespace TSAK.PetShopComp._2021.EF.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        //Write - Change
        public int InsuranceId { get; set; }
        public InsuranceEntity Insurance { get; set; }
        
        public int OwnerId { get; set; }
        public OwnerEntity Owner { get; set; }
        
        public int PetTypeId { get; set; }
        public PetTypeEntity PetType { get; set; }
    }
}