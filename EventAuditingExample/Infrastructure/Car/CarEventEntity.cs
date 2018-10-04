using System;
using EventAuditingExample.Infrastructure.Common;

namespace EventAuditingExample.Infrastructure.Car
{
    public class CarEventEntity : EventEntity
    {
        private Func<int> _carIdFunc;

        public int _carId;
        public int CarId
        {
            get { return _carId == 0 && _carIdFunc != null ? _carIdFunc() : _carId; }
            protected set { _carId = value; }
        }

        // Used by EF.
        private CarEventEntity() { }

        public CarEventEntity(Func<int> carIdFunc)
        {
            _carIdFunc = carIdFunc;
        }
    }
}
