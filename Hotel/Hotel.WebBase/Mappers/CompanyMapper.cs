using Hotel.Entities;
using Hotel.WebBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebBase.Mappers
{
    public partial class Mapper
    {
        public static CompanyModel ToModel(Company entity)
        {
            return entity == null ? null : new CompanyModel()
            {
                Id = entity.Id,
                CompanyCode = entity.CompanyCode,
                ExpiredDate = entity.ExpiredDate,
                IsActive = entity.IsActive
            };
        }

        public static List<CompanyModel> ToModel(IEnumerable<Company> entities)
        {
            return entities == null ? null : entities.Select(ToModel).ToList();
        }
    }
}
