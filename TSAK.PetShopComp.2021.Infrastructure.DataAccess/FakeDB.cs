using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Infrastructure.DataAccess
{
    public class FakeDB
    {
        public static List<Pet> pets = new List<Pet>();
        public static int _id = 1;
        
        public static List<PetType> petTypes = new List<PetType>();
        public static int _typeId = 1;

        public static List<Owner> owners = new List<Owner>();
        public static int _idOwner = 1;
    }
}