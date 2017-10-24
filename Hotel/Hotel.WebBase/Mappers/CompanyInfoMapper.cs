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
        public static CompanyInfoModel ToModel(CompanyInfo entity, Action<CompanyInfoModel, CompanyInfo> then = null)
        {
            if (entity == null) return null;
            var model = new CompanyInfoModel()
            {
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                Email1 = entity.Email1,
                Email2 = entity.Email2,
                Facebook = entity.Facebook,
                GooglePlus = entity.GooglePlus,
                LogoImageId = entity.LogoImageId,
                LongDescription = entity.LongDescription,
                MapLatitude = entity.MapLatitude,
                MapLongitude = entity.MapLongitude,
                Phone1 = entity.Phone1,
                Phone2 = entity.Phone2,
                ShortDescription = entity.ShortDescription,
                Skype = entity.Skype,
                Twitter = entity.Twitter,
                YouTube = entity.YouTube,
            };
            then?.Invoke(model, entity);
            return model;
        }

        public static List<CompanyInfoModel> ToModel(IEnumerable<CompanyInfo> entities, Action<CompanyInfoModel, CompanyInfo> then = null)
        {
            return entities?.Select(x => ToModel(x, then)).ToList();
        }
    }
}
