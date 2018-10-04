using System;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car.Events.Tire
{
    public class TireEvent : DomainEvent
    {
        public Func<int> GetTireIdFunc { get; }

        private int _tireId;
        public int TireId
        {
            get { return _tireId == 0 && GetTireIdFunc != null ? GetTireIdFunc() : _tireId; }
            protected set { _tireId = value; }
        }

        public TireEvent(int tireId, string createdBy) : base(createdBy)
        {
            TireId = tireId;
        }

        public TireEvent(Func<int> tireIdFunc, string createdBy) : base(createdBy)
        {
            GetTireIdFunc = tireIdFunc;
        }

        protected static int GetTireId(EventAuditingExample.Domain.Car.Tire tire) => tire.Id;
    }
}
