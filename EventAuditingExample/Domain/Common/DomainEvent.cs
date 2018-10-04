using System;
using Newtonsoft.Json;

namespace EventAuditingExample.Domain.Common
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime CreatedOn { get; protected set; }
        public string CreatedBy { get; protected set; }
        
        public DomainEvent(string createdBy) : this(createdBy, DateTime.UtcNow)
        {
        }

        public DomainEvent(string createdBy, DateTime createdOn)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;

            var type = this.GetType();
            EventType = type.FullName;
            EventName = type.Name;
        }

        private string _eventDataBackingField;

        public long Id { get; set; }
        public string EventData
        {
            get 
            {
                _eventDataBackingField = _eventDataBackingField ?? GetEventData();
                return _eventDataBackingField; 
            }
            protected set { _eventDataBackingField = value; }
        }
        public string EventType { get; protected set; }
        public string EventName { get; protected set; }

        public string GetEventData()
        {
            _eventDataBackingField = String.Empty;
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
