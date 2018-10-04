using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventAuditingExample.Infrastructure.EntityConfigurations
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Car.Car>
    {
        public void Configure(EntityTypeBuilder<Domain.Car.Car> carConfiguration)
        {
            carConfiguration.HasKey(o => o.Id);

            carConfiguration.Ignore(b => b.DomainEvents);

            var navigation = carConfiguration.Metadata.FindNavigation(nameof(Domain.Car.Car.Tires));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
