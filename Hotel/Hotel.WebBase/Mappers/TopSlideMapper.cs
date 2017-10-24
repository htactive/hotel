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
        public static TopSlideModel ToModel(TopSlide entity, Action<TopSlideModel, TopSlide> then = null)
        {
            if (entity == null) return null;
            var model = new TopSlideModel()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                ImageId = entity.ImageId,
                IsHidden = entity.IsHidden,
                Priority = entity.Priority,
                Text1 = entity.Text1,
                Text2 = entity.Text2,
                Text3 = entity.Text3,
                Url = entity.Url,
            };
            then?.Invoke(model, entity);
            return model;
        }

        public static List<TopSlideModel> ToModel(IEnumerable<TopSlide> entities, Action<TopSlideModel, TopSlide> then = null)
        {
            return entities?.Select(x => ToModel(x, then)).ToList();
        }
    }
}
