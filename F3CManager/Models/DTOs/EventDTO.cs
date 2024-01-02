
using DataAccess.Models;

namespace F3CManager.Models.DTOs
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOpenForRegistration { get; set; }
        public DateTime RegistrationStartTime { get; set; }
        public DateTime RegistrationEndTime { get; set; }
        public Guid OwnerId { get; set; }

        public EventDTO(Event ev)
        {
            Id = ev.Id;
            Name = ev.Name;
            StartTime = ev.StartTime;
            EndTime = ev.EndTime;
            IsOpenForRegistration = ev.IsOpenForRegistration;
            RegistrationStartTime = ev.RegistrationStartTime;
            RegistrationEndTime = ev.RegistrationEndTime;
            OwnerId = ev.OwnerId;
        }
    }
}