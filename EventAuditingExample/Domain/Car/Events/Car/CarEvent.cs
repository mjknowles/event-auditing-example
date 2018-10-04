using System;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class CarEvent : DomainEvent
    {
        private Func<int> _carIdFunc;

        private int _carId;
        public int CarId
        {
            get { return _carId == 0 && _carIdFunc != null ? _carIdFunc() : _carId; }
            protected set { _carId = value; }
        }

        public CarEvent(int carId, string createdBy) : base(createdBy)
        {
            CarId = carId;
        }

        public CarEvent(Func<int> carIdFunc, string createdBy) : base(createdBy)
        {
            _carIdFunc = carIdFunc;
        }

        protected static int GetCarId(EventAuditingExample.Domain.Car.Car car) => car.Id;
    }
}
