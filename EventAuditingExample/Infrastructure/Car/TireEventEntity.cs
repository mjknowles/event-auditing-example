using System;
using EventAuditingExample.Infrastructure.Common;

namespace EventAuditingExample.Infrastructure.Car
{
    public class TireEventEntity : EventEntity
    {
        public int TireId { get; set; }
    }
}
