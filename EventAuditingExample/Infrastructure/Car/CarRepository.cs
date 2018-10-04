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

        public async Task<Domain.Car.Car> AddAsync(Domain.Car.Car car)
        {
            var addedCar = _context.Cars.Add(car).Entity;

            // THIS IS BAD!!!!! Only here so that the Id gets created and
            // can be saved with the event.To resolve, need to create CarEntity 
            // and TireEntity classes in this project (and the converter methods
            // to and from the domain representation) then link with a foreign key.
            await _context.SaveChangesAsync();
            foreach(var devent in addedCar.DomainEvents)
            {
                var casted = devent as CarEvent;
                casted.CarId = addedCar.Id;
            }
            foreach (var addedTire in addedCar.Tires)
            {
                foreach (var devent in addedTire.DomainEvents)
                {
                    var casted = devent as TireEvent;
                    if (casted.TireId != 0) continue;

                    casted.TireId = addedTire.Id;
                }
            }

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
            _context.CarEvents.AddRange(car.DomainEvents.Select(e => (e as CarEvent).ToEntity()));
            _context.TireEvents.AddRange(car.Tires
                .SelectMany(t => t.DomainEvents.Select(e => (e as TireEvent).ToEntity())));
        }
    }
}
