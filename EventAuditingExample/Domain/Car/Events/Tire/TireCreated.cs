using System;

namespace EventAuditingExample.Domain.Car.Events.Tire
{
    public class TireCreated : TireEvent
    {
        public TireCreated(EventAuditingExample.Domain.Car.Tire tire, 
                          string createdBy) : base(tire.Id, createdBy)
        {
            Tire = tire;
        }

        public EventAuditingExample.Domain.Car.Tire Tire { get; }
    }
}
