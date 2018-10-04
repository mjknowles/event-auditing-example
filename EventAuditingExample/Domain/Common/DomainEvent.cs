using System;
namespace EventAuditingExample.Domain.Common
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime CreatedOn { get; }
        public string CreatedBy { get; }
        
        public DomainEvent(string createdBy) : this(createdBy, DateTime.UtcNow)
        {
        }

        public DomainEvent(string createdBy, DateTime createdOn)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;
        }
    }
}
