using System;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class CarEvent : DomainEvent
    {
        public int CarId { get; set; }

        public CarEvent(int carId, string createdBy) : base(createdBy)
        {
            CarId = carId;
        }
    }
}
