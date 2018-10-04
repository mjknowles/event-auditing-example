using System;
using EventAuditingExample.Domain.Car.Events.Tire;
using Newtonsoft.Json;

namespace EventAuditingExample.Infrastructure.Car
{
    public static class TireEventExtensions
    {
        public static TireEventEntity ToEntity(this TireEvent tireEvent)
        {
            var type = tireEvent.GetType();
            return new TireEventEntity()
            {
                TireId = tireEvent.TireId,
                EventData = JsonConvert.SerializeObject(tireEvent, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }),
                EventType = type.FullName,
                EventName = type.Name,
                CreatedOn = tireEvent.CreatedOn,
                CreatedBy = tireEvent.CreatedBy
            };
        }
    }
}
