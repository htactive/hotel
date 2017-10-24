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
        public static RoomImageModel ToModel(RoomImage entity, Action<RoomImageModel, RoomImage> then = null)
        {
            if (entity == null) return null;
            var model = new RoomImageModel()
            {
                Id = entity.Id,
                ImageId = entity.ImageId,
                Priority = entity.Priority,
                RoomId = entity.RoomId
            };
            then?.Invoke(model, entity);
            return model;
        }

        public static List<RoomImageModel> ToModel(IEnumerable<RoomImage> entities, Action<RoomImageModel, RoomImage> then = null)
        {
            return entities?.Select(x => ToModel(x, then)).ToList();
        }
    }
}
