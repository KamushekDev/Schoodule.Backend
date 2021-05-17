using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class LessonTimeConfig : IEntityTypeConfiguration<LessonTimeEntity>
	{
		public void Configure(EntityTypeBuilder<LessonTimeEntity> builder)
		{
			builder.ToTable("lesson_times");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Hours)
				.HasColumnName("hour")
				.IsRequired();
			builder.Property(x => x.Minutes)
				.HasColumnName("minutes")
				.IsRequired();
			builder.Property(x => x.Duration)
				.HasColumnName("duration")
				.IsRequired();
			builder.Property(x => x.Symbol)
				.HasColumnName("symbol");
			builder.Property(x => x.SchoolId)
				.HasColumnName("school_id")
				.IsRequired();

			builder.HasOne(x => x.School)
				.WithMany(x => x.LessonTimes)
				.HasForeignKey(x => x.SchoolId);

			builder.Ignore(x => x.EndTime);
		}
	}
}