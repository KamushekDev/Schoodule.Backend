using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class TeacherConfig : IEntityTypeConfiguration<TeacherEntity>
	{
		public void Configure(EntityTypeBuilder<TeacherEntity> builder)
		{
			builder.ToTable("teachers");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Firstname)
				.HasColumnName("firstname")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(x => x.Lastname)
				.HasColumnName("lastname")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(x => x.Patronymic)
				.HasColumnName("patronymic")
				.HasMaxLength(100);
			builder.Property(x => x.Email)
				.HasColumnName("email")
				.HasMaxLength(100);
			builder.Property(x => x.Phone)
				.HasColumnName("phone")
				.HasMaxLength(20);

			builder.HasOne(x => x.School)
				.WithMany(x => x.Teachers)
				.HasForeignKey(x => x.SchoolId);
		}
	}
}