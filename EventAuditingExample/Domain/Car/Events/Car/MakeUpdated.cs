using System;
namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class MakeUpdated : CarEvent
    {
        public MakeUpdated(int carId, string oldMake, string newMake, 
                           string createdBy) : base(carId, createdBy)
        {
            OldMake = oldMake;
            NewMake = newMake;
        }

        public string OldMake { get; }
        public string NewMake { get; }
    }
}
