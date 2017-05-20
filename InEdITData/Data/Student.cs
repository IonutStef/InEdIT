namespace InEdITData.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            EventStudents = new HashSet<EventStudent>();
        }

        public Guid StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        [StringLength(1000)]
        public string SchoolName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventStudent> EventStudents { get; set; }
    }
}
