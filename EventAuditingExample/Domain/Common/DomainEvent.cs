using System;
using Newtonsoft.Json;

namespace EventAuditingExample.Domain.Common
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime CreatedOn { get; protected set; }
        public string CreatedBy { get; protected set; }
        
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
