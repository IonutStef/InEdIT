namespace InEdITData.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            EventStudents = new HashSet<EventStudent>();
        }

        public Guid EventId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        public string Picture { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ScheduledDate { get; set; }

        public Guid MentorId { get; set; }

        public int AvailableSeats { get; set; }

        public DateTime CreationDateTime { get; set; }

        public virtual Mentor Mentor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventStudent> EventStudents { get; set; }
    }
}
