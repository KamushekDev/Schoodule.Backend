using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class SchoolConfig : IEntityTypeConfiguration<SchoolEntity>
	{
		public void Configure(EntityTypeBuilder<SchoolEntity> builder)
		{
			builder.ToTable("schools");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(200);
			builder.Property(x => x.SchoolTypeId)
				.HasColumnName("school_type_id")
				.IsRequired();

			builder.HasOne(x => x.SchoolType)
				.WithMany(x => x.Schools)
				.HasForeignKey(x => x.SchoolTypeId);
			builder.HasMany(x => x.Groups)
				.WithOne(x => x.School);
			builder.HasMany(x => x.Teachers)
				.WithOne(x => x.School)
				.HasForeignKey(x => x.SchoolId);
			builder.HasMany(x => x.LessonTypes)
				.WithOne(x => x.School)
				.HasForeignKey(x => x.SchoolId);

			builder.HasIndex(x => x.Name)
				.IsUnique();
		}
	}
}