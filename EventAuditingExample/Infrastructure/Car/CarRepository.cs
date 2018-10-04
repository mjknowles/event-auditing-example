using System;
using System.Linq;
using System.Threading.Tasks;
using EventAuditingExample.Domain.Car;
using EventAuditingExample.Domain.Car.Events.Car;
using EventAuditingExample.Domain.Car.Events.Tire;
using Microsoft.EntityFrameworkCore;

namespace EventAuditingExample.Infrastructure.Car
{
    public class CarRepository : ICarRepository
    {
        private readonly CarMgmtContext _context;
        public CarRepository(CarMgmtContext context)
        {
            _context = context;
        }

        public Domain.Car.Car Add(Domain.Car.Car car)
        {
            var addedCar = _context.Cars.Add(car).Entity;
            AddDomainEntityEvents(addedCar);
            return addedCar;
        }

        public async Task<Domain.Car.Car> GetAsync(int carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car != null)
            {
                await _context.Entry(car)
                    .Collection(i => i.Tires).LoadAsync();
            }

            return car;
        }

        public void Update(Domain.Car.Car car)
        {
            AddDomainEntityEvents(car);
            _context.Entry(car).State = EntityState.Modified;
        }

        private void AddDomainEntityEvents(Domain.Car.Car car)
        {
            var carEvents = car.DomainEvents?.Select(e => (e as CarEvent));
            if(carEvents != null && carEvents.Any())_context.CarEvents.AddRange(carEvents.Select(e => e.ToEntity()));

            var tireEvents = car.Tires.Where(t => t.DomainEvents != null)
                                .SelectMany(t => t.DomainEvents?.Select(e => (e as TireEvent)));
            if(tireEvents != null && tireEvents.Any()) _context.TireEvents.AddRange(tireEvents.Select(t => t.ToEntity()));
        }
    }
}
