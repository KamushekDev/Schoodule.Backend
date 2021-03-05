using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class LessonConfig : IEntityTypeConfiguration<LessonEntity>
	{
		public void Configure(EntityTypeBuilder<LessonEntity> builder)
		{
			builder.ToTable("lessons");
			builder.HasKey(x => x.LessonId);

			builder.Property(x => x.LessonId)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(x => x.SchoolId)
				.HasColumnName("group_id")
				.IsRequired();

			builder.HasOne(x => x.School)
				.WithMany(x => x.Lessons)
				.HasForeignKey(x => x.SchoolId);
		}
	}
}