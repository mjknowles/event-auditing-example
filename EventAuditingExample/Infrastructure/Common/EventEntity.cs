using System;
namespace EventAuditingExample.Infrastructure.Common
{
    public abstract class EventEntity
    {
        public long Id { get; set; }
        public string EventData { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
