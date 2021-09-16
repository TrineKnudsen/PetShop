using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.EF.Entities;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.EF.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopDbContext _ctx;
        private static List<Insurance> _insurancesTable = new List<Insurance>();

        public InsuranceRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public Insurance GetById(int id)
        {
            return _ctx.Insurances
                .Select(ie => new Insurance
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                })
                .FirstOrDefault(insurance => insurance.Id == id);
        }

        public Insurance Create(Insurance insurance)
        {
            var entity = _ctx.Add(new InsuranceEntity
            {
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        } 
    }
}