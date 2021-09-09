using System;
using System.Collections.Generic;

namespace TSAK.PetShopComp._2021.Model
{
    public class Owner
    {
        public int Id { get; set; }
        
        public String Name { get; set; }
        
        public String Address { get; set; }

        public String Email { get; set; }

        public List<Pet> Pets { get; set; }
        
    }
}