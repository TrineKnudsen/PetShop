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

        public List<Insurance> ReadAll()
        {
            return _ctx.Insurances
                .Select(i => new Insurance
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price
                })
                .ToList();
        }

        public Insurance Delete(int id)
        {
            var entity = _ctx.Remove(new InsuranceEntity { Id = id}).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id
            };
        }

        public Insurance Update(Insurance insurance)
        {
            var insuranceEntity = new InsuranceEntity
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
            var entity = _ctx.Update(insuranceEntity).Entity;
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