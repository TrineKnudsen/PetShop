using System.Collections.Generic;
using System.Linq;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.EF.Entities;
using TSAK.PetShopComp._2021.Filtering;
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

        public List<Insurance> ReadAll(Filter filter)
        {
            var selectQuery = _ctx.Insurances
                .Select(ie => new Insurance
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                });
            if (filter.OrderDir.ToLower().Equals("asc"))
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderBy(i => i.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderBy(i => i.Id);
                        break;
                    case "price":
                        selectQuery = selectQuery.OrderBy(i => i.Price);
                        break;
                }
            }
            else
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderByDescending(i => i.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderByDescending(i => i.Id);
                        break;
                    case "price":
                        selectQuery = selectQuery.OrderByDescending(i => i.Price);
                        break;
                }
            }

            selectQuery = selectQuery.Where(i => i.Name.ToLower().StartsWith(filter.Search.ToLower()));
            var query = selectQuery
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);
            return query.ToList();
            
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

        public int TotalCount()
        {
            return _ctx.Insurances.Count();
        }
    }
}