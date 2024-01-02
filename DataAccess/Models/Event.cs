using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Models
{
    /// <summary>
    /// DB table Model for competition events.
    /// </summary>
    [Table("events")]
    public class Event : GuidIdModel
    {
        /// <summary>
        /// Name of the event.
        /// </summary>
        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        /// <summary>
        /// Time when event starts.
        /// </summary>
        [Required]
        [Column("start_time")]
        public DateTime StartTime { get; set; }

        private DateTime endTime;

        /// <summary>
        /// Time when event ends.
        /// </summary>
        [Required]
        [Column("end_time")]
        public DateTime EndTime { 
            get { return endTime; }
            set {
                if (value <= StartTime) {
                    throw new ArgumentException($"{nameof(value)} must be after {nameof(StartTime)}");
                }

                endTime = value; 
            }
        }

        /// <summary>
        /// If true, this event is open for new competitors to register.
        /// Also depends on the registration start and end times.
        /// </summary>
        [Required]
        [Column("is_open_for_registration")]
        public bool IsOpenForRegistration { get; set; }

        /// <summary>
        /// New competitors can register after this time.
        /// </summary>
        [Required]
        [Column("registration_start_time")]
        public DateTime RegistrationStartTime { get; set; }

        private DateTime registrationEndTime;

        /// <summary>
        /// New competitors can register before this time.
        /// </summary>
        [Required]
        [Column("registration_end_time")]
        public DateTime RegistrationEndTime { 
            get { return registrationEndTime; }
            set {
                if (value <= RegistrationStartTime) {
                    throw new ArgumentException($"{nameof(value)} must be after {nameof(RegistrationStartTime)}");
                }

                registrationEndTime = value; 
            }
        }

        /// <summary>
        /// The user who owns this event. The owner has full control over the event.
        /// </summary>
        [Required]
        [Column("owner_id")]
        public Guid OwnerId { get; set; }

        public virtual ICollection<CompetitionClass> CompetitionClasses { get; set; }
        public virtual User Owner { get; set; }
        
        public class EventConfiguration : IEntityTypeConfiguration<Event>
        {
            public void Configure(EntityTypeBuilder<Event> builder)
            {
                builder.HasOne(e => e.Owner).WithMany(u => u.Events).HasForeignKey(e => e.OwnerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(true);
            }
        }
    }
}