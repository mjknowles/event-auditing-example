using System;
using System.Threading.Tasks;
using EventAuditingExample.Domain.Car;
using EventAuditingExample.Domain.Car.Events.Car;
using EventAuditingExample.Domain.Car.Events.Tire;
using EventAuditingExample.Infrastructure.Car;
using EventAuditingExample.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EventAuditingExample.Infrastructure
{
    public class CarMgmtContext : DbContext
    {
        public DbSet<Domain.Car.Car> Cars { get; set; }
        public DbSet<CarEvent> CarEvents { get; set; }

        public DbSet<Tire> Tires { get; set; }
        public DbSet<TireEvent> TireEvents { get; set; }

        public CarMgmtContext()
        {
        }

        public CarMgmtContext(DbContextOptions<CarMgmtContext> options)
        : base(options)
        { }

        public async Task<bool> SaveChangesAsync()
        {
            // Outside the scope of the example but here would be a great
            // place to fire off all of your events utilizing something
            // like Mediatr. Careful though bc firing the events here
            // means that your new entities don't have ids yet

            await base.SaveChangesAsync();

            // Could also fire events here but that means potentially additional
            // calls to the database. At least you have your ids though.

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TireEntityTypeConfiguration());
        }
    }
}
