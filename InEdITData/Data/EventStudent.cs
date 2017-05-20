namespace InEdITData.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class EventStudent
    {
        public Guid? EventId { get; set; }

        public Guid? StudentId { get; set; }

        [Key]
        public DateTime ApplyDate { get; set; }

        public virtual Event Event { get; set; }

        public virtual Student Student { get; set; }
    }
}
