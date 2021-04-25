using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class LiteratureConfig:IEntityTypeConfiguration<LiteratureEntity>
	{
		public void Configure(EntityTypeBuilder<LiteratureEntity> builder)
		{
			builder.ToTable("literatures");
			builder.HasKey(x => x.Id);
			
			builder.Property(x=>x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(1000);
			builder.Property(x => x.Reference)
				.HasColumnName("reference")
				.HasMaxLength(100);
			builder.Property(x => x.GroupId)
				.HasColumnName("group_id")
				.IsRequired();
			builder.Property(x => x.LessonId)
				.HasColumnName("lesson_id")
				.IsRequired();

			builder.HasOne(x => x.Lesson)
				.WithMany(x => x.Literatures)
				.HasForeignKey(x => x.LessonId);
			builder.HasOne(x => x.Group)
				.WithMany(x => x.Literatures)
				.HasForeignKey(x => x.GroupId);
		}
	}
}