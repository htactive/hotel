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
        public static ServiceModel ToModel(Service entity, Action<ServiceModel, Service> then = null)
        {
            if (entity == null) return null;
            var model = new ServiceModel()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                CoverImageId = entity.CoverImageId,
                Html = entity.Html,
                IsHidden = entity.IsHidden,
                ShortDescription = entity.ShortDescription,
                Slug = entity.Slug,
                Title = entity.Title,
            };

            then?.Invoke(model, entity);
            return model;
        }

        public static List<ServiceModel> ToModel(IEnumerable<Service> entities, Action<ServiceModel, Service> then = null)
        {
            return entities?.Select(x => ToModel(x, then)).ToList();
        }
    }
}
