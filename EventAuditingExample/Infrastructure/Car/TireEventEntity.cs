using System;
using EventAuditingExample.Infrastructure.Common;

namespace EventAuditingExample.Infrastructure.Car
{
    public class TireEventEntity : EventEntity
    {
        private Func<int> _tireIdFunc;

        public int _tireId;
        public int TireId
        {
            get { return _tireId == 0 && _tireIdFunc != null ? _tireIdFunc() : _tireId; }
            protected set { _tireId = value; }
        }

        // Used by EF.
        private TireEventEntity() { }

        public TireEventEntity(Func<int> tireIdFunc)
        {
            _tireIdFunc = tireIdFunc;
        }
    }
}
