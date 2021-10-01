using System.Collections.Generic;
using TSAK.PetShopComp._2021.Filtering;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
        
        Insurance Create(Insurance insurance);
        
        List<Insurance> ReadAll(Filter filter);
        Insurance Delete(int id);
        Insurance Update(Insurance insurance);
        int TotalCount();
    }
}