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
        public static UserFeedbackModel ToModel(UserFeedback entity)
        {
            return entity == null ? null : new UserFeedbackModel()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Content = entity.Content,
                Email = entity.Email,
                Name = entity.Name,
                Phone = entity.Phone,
                Title = entity.Title
            };
        }

        public static List<UserFeedbackModel> ToModel(IEnumerable<UserFeedback> entities)
        {
            return entities == null ? null : entities.Select(ToModel).ToList();
        }
    }
}
