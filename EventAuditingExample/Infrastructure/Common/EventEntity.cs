using System;
using Newtonsoft.Json;

namespace EventAuditingExample.Infrastructure.Common
{
    public class EventEntity
    {
        public EventEntity()
        {
        }

        private string _eventDataBackingField;

        public int Id { get; set; }
        public string EventData
        {
            get
            {
                _eventDataBackingField = _eventDataBackingField ?? GetEventData();
                return _eventDataBackingField;
            }
            protected set { _eventDataBackingField = value; }
        }
       
        public string EventType { get; set; }
        public string EventName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

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
