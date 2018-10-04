using System;
namespace EventAuditingExample.Domain.Car.Events.Car
{
    public class ModelUpdated : CarEvent
    {
        public ModelUpdated(int carId, string oldModel, string newModel, 
                           string createdBy) : base(carId, createdBy)
        {
            OldModel = oldModel;
            NewModel = newModel;
        }

        public string OldModel { get; }
        public string NewModel { get; }
    }
}
