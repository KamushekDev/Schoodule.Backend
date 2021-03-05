using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }

		public DbSet<SchoolEntity> Schools { get; set; }
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<SchoolTypeEntity> SchoolTypes { get; set; }
		public DbSet<GroupEntity> Groups { get; set; }
		public DbSet<LessonEntity> Lessons { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}