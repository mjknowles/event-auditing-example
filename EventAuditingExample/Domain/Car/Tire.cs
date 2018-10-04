using System;
using EventAuditingExample.Domain.Car.Events.Tire;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car
{
    public class Tire : Entity
    {
        public int _mileage;

        public Tire()
        {
        }

        public Tire(int mileage, string createdBy)
        {
            _mileage = mileage;
            this.AddDomainEvent(new TireCreated(this, createdBy));
        }

        public void SetMileage(int mileage, string whodis)
        {
            this.AddDomainEvent(new MileageUpdated(this.Id, _mileage, mileage, whodis));
            _mileage = mileage;
        }
    }
}
