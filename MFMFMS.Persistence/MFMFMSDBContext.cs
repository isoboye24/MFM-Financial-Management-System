using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence
{
    public class MFMFMSDBContext : DbContext
    {
        public MFMFMSDBContext(DbContextOptions<MFMFMSDBContext> options) : base(options)
        {

        }

        protected MFMFMSDBContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MFMFMSDBContext).Assembly);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Giving> Givings { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
