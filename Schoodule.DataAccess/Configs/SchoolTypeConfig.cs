using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class SchoolTypeConfig : IEntityTypeConfiguration<SchoolTypeEntity>
	{
		public void Configure(EntityTypeBuilder<SchoolTypeEntity> builder)
		{
			builder.ToTable("school_type");
			builder.HasKey(x => x.SchoolTypeId);

			builder.Property(x => x.SchoolTypeId)
				.HasColumnName("school_type_id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);

			builder.HasMany(x => x.Schools)
				.WithOne(x => x.SchoolType)
				.HasForeignKey(x => x.SchoolTypeId);
		}
	}
}