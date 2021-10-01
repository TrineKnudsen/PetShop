using System;
using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Filtering;
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

        public List<Insurance> ReadAll(Filter filter)
        {
            if (filter == null || filter.Limit <1 || filter.Limit >100)
            {
                throw new ArgumentException("Filter limit must be between 1 to 100");
            }
            
            var totalCount = TotalCount();
            var maxPageCount = Math.Ceiling((double) totalCount / filter.Limit);
            if (filter.Page <1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException($"Filter must be between 1 and {maxPageCount}");
            }
            return _insuranceRepository.ReadAll(filter).ToList();
        }
        
        private double TotalCount()
        {
            return _insuranceRepository.TotalCount();
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