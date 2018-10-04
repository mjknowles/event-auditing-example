using System;
using System.Linq;
using System.Threading.Tasks;
using EventAuditingExample.Domain.Car;
using EventAuditingExample.Domain.Car.Events.Car;
using EventAuditingExample.Domain.Car.Events.Tire;
using EventAuditingExample.Infrastructure;
using EventAuditingExample.Infrastructure.Car;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EventAuditingExample.Tests
{
    public class EventTests
    {
        private string me = "michael";

        [Fact]
        public async Task AllEventsLogged()
        {
            var tire = new Tire(0, me);
            var car = new Car("toyota", "camry", me);
            car.AddTire(tire, me);

            var options = new DbContextOptionsBuilder<CarMgmtContext>()
                .UseInMemoryDatabase(databaseName: "all_events_logged_to_db")
                .Options;

            Car createdCar = null;
            Tire createdTire = null;
            using (var context = new CarMgmtContext(options))
            {
                var repo = new CarRepository(context);

                createdCar = await repo.AddAsync(car);
                createdTire = createdCar.Tires.Single();
                await context.SaveChangesAsync();
            }

            using (var context = new CarMgmtContext(options))
            {
                var repo = new CarRepository(context);

                var carCreatedEvent = context.CarEvents
                    .Single(e => e.EventName == nameof(CarCreated));

                var tireCreatedEvent = context.TireEvents
                    .Single(e => e.TireId == createdTire.Id);

                createdCar.SetMake("new make", me);
                repo.Update(createdCar);
                await context.SaveChangesAsync();
            }

            using (var context = new CarMgmtContext(options))
            {
                var repo = new CarRepository(context);

                var carUpdatedEvent = context.CarEvents
                .Single(e => e.EventName == nameof(MakeUpdated));

                createdCar.SetTireMileage(createdTire.Id, 1000, me);
                repo.Update(createdCar);

                await context.SaveChangesAsync();
            }

            using (var context = new CarMgmtContext(options))
            {
                var tireUpdatedEvent = context.TireEvents
                    .Single(e => e.EventName == nameof(MileageUpdated));
            }
        }
    }
}
