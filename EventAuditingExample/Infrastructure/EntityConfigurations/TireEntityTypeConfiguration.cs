using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventAuditingExample.Infrastructure.EntityConfigurations
{
    public class TireEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Car.Tire>
    {
        public void Configure(EntityTypeBuilder<Domain.Car.Tire> tireConfiguration)
        {
            tireConfiguration.HasKey(o => o.Id);

            tireConfiguration.Ignore(b => b.DomainEvents);
        }
    }
}
