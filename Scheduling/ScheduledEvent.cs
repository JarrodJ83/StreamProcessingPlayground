using System;

namespace  Scheduling
{
    public class ScheduledEvent
    {
        public int Id { get; set; }
        public string Name { get; set ;}
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        
        public ScheduledEvent(string name, DateTime startDateTime, DateTime endDateTime)
        {
            Name = Name;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}