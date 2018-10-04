using System;
namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class CarDeleted : CarEvent
    {
        public CarDeleted(int carId, string createdBy) : base(carId, createdBy)
        {
        }
    }
}
