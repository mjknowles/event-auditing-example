using System;
namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class TireAdded : CarEvent
    {
        public int TireId
        {
            get;
            set;
        }

        public TireAdded(int tireId, Domain.Car.Car car, string createdBy) 
            : base(() => GetCarId(car), createdBy)
        {
            TireId = tireId;
        }
    }
}
