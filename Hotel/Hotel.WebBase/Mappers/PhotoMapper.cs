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
        public static PhotoModel ToModel(Photo entity, Action<PhotoModel, Photo> then = null)
        {
            if (entity == null) return null;
            var model = new PhotoModel()
            {
                Id = entity.Id,
                Description = entity.Description,
                Title = entity.Title,
                ImageId = entity.ImageId
            };
            then?.Invoke(model, entity);
            return model;
        }

        public static List<PhotoModel> ToModel(IEnumerable<Photo> entities, Action<PhotoModel, Photo> then = null)
        {
            return entities?.Select(x => ToModel(x, then)).ToList();
        }
    }
}
