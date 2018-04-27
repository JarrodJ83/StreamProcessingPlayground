using System;
using System.Threading.Tasks;

namespace Scheduling
{
    public interface IScheduler
    {
        Task<ScheduledEvent> CreateEventAsync(string name, DateTime startDateTime, DateTime endDateTime);

        Task AddAttendeeAsync(ScheduledEvent scheduledEvent);
    }
}