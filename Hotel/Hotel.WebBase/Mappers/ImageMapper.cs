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
        public static ImageModel ToModel(Image entity)
        {
            if (entity == null) return null;
            var imageUrl = entity.Url;
            if (!string.IsNullOrEmpty(entity.S3FileKey))
            {
                imageUrl = string.Format("https://s3-ap-southeast-1.amazonaws.com/hotelsdanang/{0}", entity.S3FileKey);
            }
            return entity == null ? null : new ImageModel()
            {
                Id = entity.Id,
                Url = imageUrl
            };
        }

        public static List<ImageModel> ToModel(IEnumerable<Image> entities)
        {
            return entities == null ? null : entities.Select(ToModel).ToList();
        }
    }
}
