using System;
namespace EventAuditingExample.Domain.Car.Events.Tire
{
    public class TireDeleted : TireEvent
    {
        public TireDeleted(int tireId, string createdBy) : base(tireId, createdBy)
        {
        }
    }
}
