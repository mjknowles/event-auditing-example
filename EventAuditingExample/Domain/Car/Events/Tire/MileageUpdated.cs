using System;
namespace EventAuditingExample.Domain.Car.Events.Tire
{
    public class MileageUpdated : TireEvent
    {
        public MileageUpdated(int tireId, int oldMileage, int newMileage,
                              string createdBy) : base(tireId, createdBy)
        {
            OldMileage = oldMileage;
            NewMileage = newMileage;
        }

        public int OldMileage { get; }
        public int NewMileage { get; }
    }
}
