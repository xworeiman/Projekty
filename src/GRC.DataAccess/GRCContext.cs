namespace GRC.DataAccess
{
    using GRC.DataAccess.Configuration;
    using GRC.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public partial class GrcContext : DbContext
    {
        public GrcContext()
        {
        }

        public GrcContext(DbContextOptions<GrcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ControlMechanism> ControlMechanism { get; set; }
        public virtual DbSet<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Origin> Origin { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<SubProcess> SubProcess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GRC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OriginConfiguration());

            modelBuilder.ApplyConfiguration(new ProcessConfiguration());

            modelBuilder.ApplyConfiguration(new SubProcessConfiguration());

            modelBuilder.ApplyConfiguration(new StageConfiguration());

            modelBuilder.ApplyConfiguration(new ControlMechanismConfiguration());

            modelBuilder.ApplyConfiguration(new ControlMechanismRelationsConfiguration());

            //OnModelCreatingPartial(modelBuilder)
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    }
}
