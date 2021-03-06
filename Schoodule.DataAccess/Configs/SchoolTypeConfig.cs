using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class SchoolTypeConfig : IEntityTypeConfiguration<SchoolTypeEntity>
	{
		public void Configure(EntityTypeBuilder<SchoolTypeEntity> builder)
		{
			builder.ToTable("school_types");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);

			builder.HasMany(x => x.Schools)
				.WithOne(x => x.Type)
				.HasForeignKey(x => x.SchoolTypeId);
		}
	}
}