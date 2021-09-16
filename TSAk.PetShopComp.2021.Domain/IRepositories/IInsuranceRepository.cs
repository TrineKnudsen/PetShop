using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
        Insurance Create(Insurance insurance);
    }
}