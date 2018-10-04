using System;
using EventAuditingExample.Domain.Car.Events.Tire;

namespace EventAuditingExample.Infrastructure.Car
{
    public static class TireEventExtensions
    {
        public static TireEventEntity ToEntity(this TireEvent tireEvent)
        {
            var type = tireEvent.GetType();
            return new TireEventEntity(
                tireEvent.GetTireIdFunc ?? (() => tireEvent.TireId))
            {
                EventType = type.FullName,
                EventName = type.Name,
                CreatedOn = tireEvent.CreatedOn,
                CreatedBy = tireEvent.CreatedBy
            };
        }
    }
}
