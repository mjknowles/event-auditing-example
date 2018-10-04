using System;
using EventAuditingExample.Domain.Car.Events.Car;

namespace EventAuditingExample.Infrastructure.Car
{
    public static class CarEventExtensions
    {
        public static CarEventEntity ToEntity(this CarEvent carEvent)
        {
            var type = carEvent.GetType();
            return new CarEventEntity(
                carEvent.GetCarIdFunc ?? (() => carEvent.CarId))
            {
                EventType = type.FullName,
                EventName = type.Name,
                CreatedOn = carEvent.CreatedOn,
                CreatedBy = carEvent.CreatedBy
            };
        }
    }
}
