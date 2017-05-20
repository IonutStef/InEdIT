namespace InEdITData.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Mentor")]
    public partial class Mentor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mentor()
        {
            Events = new HashSet<Event>();
        }

        public Guid MentorId { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Ocupation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
