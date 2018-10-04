using System;
using EventAuditingExample.Domain.Car.Events.Car;
using Newtonsoft.Json;

namespace EventAuditingExample.Infrastructure.Car
{
    public static class CarEventExtensions
    {
        public static CarEventEntity ToEntity(this CarEvent carEvent)
        {
            var type = carEvent.GetType();
            return new CarEventEntity()
            {
                CarId = carEvent.CarId,
                EventData = JsonConvert.SerializeObject(carEvent, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }),
                EventType = type.FullName,
                EventName = type.Name,
                CreatedOn = carEvent.CreatedOn,
                CreatedBy = carEvent.CreatedBy
            };
        }
    }
}
