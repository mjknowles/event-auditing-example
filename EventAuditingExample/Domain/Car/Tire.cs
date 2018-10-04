using System;
using EventAuditingExample.Domain.Car.Events.Tire;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car
{
    public class Tire : Entity
    {
        public int Mileage { get; protected set; }

        public Tire()
        {
        }

        // Used by EF.
        private Tire(int mileage)
        {
            Mileage = mileage;
        }

        public static Tire Create(int mileage, string createdBy)
        {
            var tire = new Tire(mileage);
            tire.AddDomainEvent(new TireCreated(tire, createdBy));
            return tire;
        }

        public void SetMileage(int mileage, string whodis)
        {
            this.AddDomainEvent(new MileageUpdated(this.Id, Mileage, mileage, whodis));
            Mileage = mileage;
        }
    }
}
