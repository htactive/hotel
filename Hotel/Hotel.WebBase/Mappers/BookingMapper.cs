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
        public static BookingModel ToModel(Booking entity, Action<BookingModel, Booking> then = null)
        {
            if (entity == null) return null;
            var model = new BookingModel()
            {
                Id = entity.Id,
                Adults = entity.Adults,
                CheckInDate = entity.CheckInDate,
                CheckOutDate = entity.CheckOutDate,
                Children = entity.Children,
                CompanyId = entity.CompanyId,
                Email = entity.Email,
                Phone = entity.Phone,
                Status = entity.Status
            };
            then?.Invoke(model, entity);
            return model;
        }

        public static List<BookingModel> ToModel(IEnumerable<Booking> entities, Action<BookingModel, Booking> then = null)
        {
            return entities?.Select(x => ToModel(x, then)).ToList();
        }
    }
}
