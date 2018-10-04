using System;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car.Events.Tire
{
    public class TireEvent : DomainEvent
    {
        private Func<int> _tireIdFunc;

        private int _tireId;
        public int TireId
        {
            get { return _tireId == 0 && _tireIdFunc != null ? _tireIdFunc() : _tireId; }
            protected set { _tireId = value; }
        }

        public TireEvent(int tireId, string createdBy) : base(createdBy)
        {
            TireId = tireId;
        }

        public TireEvent(Func<int> tireIdFunc, string createdBy) : base(createdBy)
        {
            _tireIdFunc = tireIdFunc;
        }

        protected static int GetTireId(EventAuditingExample.Domain.Car.Tire tire) => tire.Id;
    }
}
