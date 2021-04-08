using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;
using Contract.Enums;

namespace Schoodule.DataAccess.Configs
{
	public class ClassConfig : IEntityTypeConfiguration<ClassEntity>
	{
		public void Configure(EntityTypeBuilder<ClassEntity> builder)
		{
			builder.ToTable("classes");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Description)
				.HasMaxLength(500);
			builder.Property(x => x.LessonId)
				.HasColumnName("lesson_id")
				.IsRequired();
			builder.Property(x => x.LessonTypeId)
				.HasColumnName("lesson_type_id")
				.IsRequired();
			builder.Property(x => x.LessonTimeId)
				.HasColumnName("lesson_time_id")
				.IsRequired();
			builder.Property(x => x.SchoolId)
				.HasColumnName("school_id")
				.IsRequired();
			builder.Property(x => x.TeacherId)
				.HasColumnName("teacher_id")
				.IsRequired();
			builder.Property(x => x.GroupId)
				.HasColumnName("group_id")
				.IsRequired();
			builder.Property(x => x.RoomId)
				.HasColumnName("room_id")
				.IsRequired();
			builder.Property(x => x.Weekday)
				.HasColumnName("weekday")
				.IsRequired();
			builder.Property(x => x.WeekType)
				.HasColumnName("week_type")
				.IsRequired()
				.HasDefaultValue(WeekType.Both);

			builder.HasOne(x => x.Lesson)
				.WithMany(x => x.Classes)
				.HasForeignKey(x => x.LessonId);
			builder.HasOne(x => x.LessonType)
				.WithMany(x => x.Classes)
				.HasForeignKey(x => x.LessonTypeId);
			builder.HasOne(x => x.LessonTime)
				.WithMany(x => x.Classes)
				.HasForeignKey(x => x.LessonTimeId);
			builder.HasOne(x => x.School)
				.WithMany(x => x.Classes)
				.HasForeignKey(x => x.SchoolId);
			builder.HasOne(x => x.Teacher)
				.WithMany(x => x.Classes)
				.HasForeignKey(x => x.TeacherId);
			builder.HasOne(x => x.Group)
				.WithMany(x => x.Classes)
				.HasForeignKey(x => x.GroupId);
			builder.HasOne(x => x.Room)
				.WithMany(x => x.Classes)
				.HasForeignKey(x => x.RoomId);
		}
	}
}