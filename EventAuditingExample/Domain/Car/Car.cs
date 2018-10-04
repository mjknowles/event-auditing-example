using System;
using System.Collections.Generic;
using System.Linq;
using EventAuditingExample.Domain.Car.Events.Car;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car
{
    public class Car : Entity, IAggregateRoot
    {
        public string Make { get; protected set; }
        public string Model { get; protected set; }

        private List<Tire> _tires;
        public IReadOnlyCollection<Tire> Tires => _tires?.AsReadOnly();

        // Used by EF when rehydrating.
        private Car(string make, string model)
        {
            _tires = new List<Tire>();
            Make = make;
            Model = model;
        }

        // Should be used when creating a new car.
        public static Car Create(string make, string model, string createdBy)
        {
            var car = new Car(make, model);
            car.AddDomainEvent(new CarCreated(car, createdBy));
            return car;
        }

        public void AddTire(Tire tire, string whodis)
        {
            _tires.Add(tire);
            this.AddDomainEvent(new TireAdded(tire.Id, this, whodis));
        }

        public void SetTireMileage(int id, int miles, string whodis)
        {
            var tire = _tires.FirstOrDefault(t => t.Id == id);
            if (tire == null) return;

            tire.SetMileage(miles, whodis);
        }

        public void SetMake(string make, string whodis)
        {
            this.AddDomainEvent(new MakeUpdated(this.Id, Make, make, whodis));
            Make = make;
        }

        public void SetModel(string model, string whodis)
        {
            this.AddDomainEvent(new ModelUpdated(this.Id, Model, model, whodis));
            Model = model;
        }

        public void Delete(string whodis)
        {
            this.AddDomainEvent(new CarDeleted(this.Id, whodis));
            IsDeleted = true;
        }
    }
}
