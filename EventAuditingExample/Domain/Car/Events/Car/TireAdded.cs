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

        public TireAdded(int tireId, int carId, string createdBy) 
            : base(carId, createdBy)
        {
            TireId = tireId;
        }
    }
}
