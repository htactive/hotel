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
        public static ArticleModel ToModel(Article entity, Action<ArticleModel, Article> then = null)
        {
            if (entity == null) return null;
            var model = new ArticleModel()
            {
                Id = entity.Id,
                Author = entity.Author,
                CompanyId = entity.CompanyId,
                CoverImageId = entity.CoverImageId,
                CreatedDate = entity.CreatedDate,
                Html = entity.Html,
                IsHidden = entity.IsHidden,
                ShortDescription = entity.ShortDescription,
                Slug = entity.Slug,
                Title = entity.Title
            };
            then?.Invoke(model, entity);
            return model;
        }

        public static List<ArticleModel> ToModel(IEnumerable<Article> entities, Action<ArticleModel, Article> then = null)
        {
            return entities == null ? null : entities.Select(x => ToModel(x, then)).ToList();
        }
    }
}
