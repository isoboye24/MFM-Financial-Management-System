using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Domain.Common;
using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence
{
    public class MFMFMSDBContext : DbContext
    {
        private readonly IUserService? _userService;
        public MFMFMSDBContext(DbContextOptions<MFMFMSDBContext> options, IUserService? userService) : base(options)
        {
            _userService = userService;
        }

        protected MFMFMSDBContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MFMFMSDBContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (_userService is not null)
            {
                foreach (var entry in ChangeTracker.Entries<Auditable>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreationTime = DateTime.UtcNow;
                            entry.Entity.CreatedBy = _userService.GetUserId();
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedDate = DateTime.UtcNow;
                            entry.Entity.LastMofifiedBy = _userService.GetUserId();
                            break;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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
