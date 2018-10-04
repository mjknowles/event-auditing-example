using System;
using System.Collections.Generic;
using System.Linq;
using EventAuditingExample.Domain.Car.Events.Car;
using EventAuditingExample.Domain.Common;

namespace EventAuditingExample.Domain.Car
{
    public class Car : Entity, IAggregateRoot
    {
        private string _make;
        private string _model;
        private bool _isDeleted;

        private List<Tire> _tires;
        public IReadOnlyCollection<Tire> Tires => _tires?.AsReadOnly();

        public Car()
        {
            _tires = new List<Tire>();
        }

    
        // Should be used when created a new car.
        // Alternatively could use a static create method.
        public Car(string make, string model, string createdBy) : this()
        {
            _make = make;
            _model = model;
            this.AddDomainEvent(new CarCreated(this, createdBy));
        }

        public void AddTire(Tire tire, string whodis)
        {
            _tires.Add(tire);
            this.AddDomainEvent(new TireAdded(tire.Id, this.Id, whodis));
        }

        public void SetTireMileage(int id, int miles, string whodis)
        {
            var tire = _tires.FirstOrDefault(t => t.Id == id);
            if (tire == null) return;

            tire.SetMileage(miles, whodis);
        }

        public void SetMake(string make, string whodis)
        {
            this.AddDomainEvent(new MakeUpdated(this.Id, _make, make, whodis));
            _make = make;
        }

        public void SetModel(string model, string whodis)
        {
            this.AddDomainEvent(new ModelUpdated(this.Id, _model, model, whodis));
            _model = model;
        }

        public void Delete(string whodis)
        {
            this.AddDomainEvent(new CarDeleted(this.Id, whodis));
        }
    }
}
