using System;
namespace EventAuditingExample.Domain.Common
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
