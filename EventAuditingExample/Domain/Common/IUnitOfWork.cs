using System;
using System.Threading.Tasks;

namespace EventAuditingExample.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
