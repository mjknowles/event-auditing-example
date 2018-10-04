using System;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car.Events.Tire
{
    public class TireEvent : DomainEvent
    {
        public int TireId
        {
            get; set;
        }

        public TireEvent(int tireId, string createdBy) : base(createdBy)
        {
            TireId = tireId;
        }
    }
}
