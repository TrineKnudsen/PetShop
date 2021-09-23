using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.IService;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.Domain.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public Insurance GetById(int id)
        {
            return _insuranceRepository.GetById(id);
        }

        public Insurance Create(Insurance insurance)
        {
            return _insuranceRepository.Create(insurance);
        }

        public List<Insurance> ReadAll()
        {
            return _insuranceRepository.ReadAll();
        }

        public Insurance Delete(int id)
        {
            return _insuranceRepository.Delete(id);
        }

        public Insurance Update(Insurance insurance)
        {
            return _insuranceRepository.Update(insurance);
        }
    }
}