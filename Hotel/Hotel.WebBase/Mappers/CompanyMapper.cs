﻿using Hotel.Entities;
using Hotel.WebBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebBase.Mappers
{
    public partial class Mapper
    {
        public static CompanyModel ToModel(Company entity, Action<CompanyModel, Company> then = null)
        {
            if (entity == null) return null;
            var model = new CompanyModel()
            {
                Id = entity.Id,
                CompanyCode = entity.CompanyCode,
                ExpiredDate = entity.ExpiredDate,
                IsActive = entity.IsActive
            };
            then?.Invoke(model, entity);
            return model;
        }

        public static List<CompanyModel> ToModel(IEnumerable<Company> entities, Action<CompanyModel, Company> then = null)
        {
            return entities?.Select(x => ToModel(x, then)).ToList();
        }
    }
}
