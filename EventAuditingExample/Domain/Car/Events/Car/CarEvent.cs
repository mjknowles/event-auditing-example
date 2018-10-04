using System;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class CarEvent : DomainEvent
    {
        public Func<int> GetCarIdFunc { get; }

        private int _carId;
        public int CarId
        {
            get { return _carId == 0 && GetCarIdFunc != null ? GetCarIdFunc() : _carId; }
            protected set { _carId = value; }
        }

        public CarEvent(int carId, string createdBy) : base(createdBy)
        {
            CarId = carId;
        }

        public CarEvent(Func<int> carIdFunc, string createdBy) : base(createdBy)
        {
            GetCarIdFunc = carIdFunc;
        }

        protected static int GetCarId(EventAuditingExample.Domain.Car.Car car) => car.Id;
    }
}
