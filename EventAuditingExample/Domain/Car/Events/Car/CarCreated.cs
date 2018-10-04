using System;

namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class CarCreated : CarEvent
    {
        public CarCreated(EventAuditingExample.Domain.Car.Car car,
                          string createdBy) : base(() => GetCarId(car), createdBy)
        {
            Car = car;
        }

        public EventAuditingExample.Domain.Car.Car Car { get; }
    }
}
