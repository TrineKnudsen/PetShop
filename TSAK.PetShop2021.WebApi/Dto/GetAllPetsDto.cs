using System.Collections.Generic;

namespace TSAK.PetShop2021.WebApi.Dto
{
    public class GetAllPetsDto
    {
        public List<GetPetDto> List { get; set; }
    }
}