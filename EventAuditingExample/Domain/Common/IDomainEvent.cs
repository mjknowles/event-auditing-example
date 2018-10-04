using System;
namespace EventAuditingExample.Domain.Common
{
    public interface IDomainEvent
    {
        DateTime CreatedOn { get; }
        string CreatedBy { get; }
    }
}
