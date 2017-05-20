namespace InEdITData.Data
{
    using System.Data.Entity;

    public partial class InEdItModel : DbContext
    {
        public InEdItModel()
            : base("name=InEdIt")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<EventStudent> EventStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
