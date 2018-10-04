using System;
using EventAuditingExample.Infrastructure.Common;

namespace EventAuditingExample.Infrastructure.Car
{
    public class CarEventEntity : EventEntity
    {
        public int CarId { get; set; }
    }
}
