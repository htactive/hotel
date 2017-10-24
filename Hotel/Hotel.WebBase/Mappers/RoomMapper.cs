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
        public static RoomModel ToModel(Room entity, Action<RoomModel, Room> then = null)
        {
            if (entity == null) return null;
            var model = new RoomModel()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                CoverImageId = entity.CoverImageId,
                Description = entity.Description,
                FeaturesJson = entity.FeaturesJson,
                IsHidden = entity.IsHidden,
                Name = entity.Name,
                Price = entity.Price,
                Priority = entity.Priority,
                Slug = entity.Slug,
            };

            then?.Invoke(model, entity);
            return model;
        }

        public static List<RoomModel> ToModel(IEnumerable<Room> entities, Action<RoomModel, Room> then = null)
        {
            return entities == null ? null : entities.Select(x => ToModel(x, then)).ToList();
        }
    }
}
