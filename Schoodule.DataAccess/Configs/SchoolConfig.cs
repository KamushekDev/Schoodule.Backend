using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class SchoolConfig : IEntityTypeConfiguration<SchoolEntity>
	{
		public void Configure(EntityTypeBuilder<SchoolEntity> builder)
		{
			builder.ToTable("school");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("school_id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(200);
			builder.Property(x => x.Type)
				.HasColumnName("school_type")
				.IsRequired();

			builder.HasIndex(x => x.Name)
				.IsUnique();
		}
	}
}