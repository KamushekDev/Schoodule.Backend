using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class GroupConfig : IEntityTypeConfiguration<GroupEntity>
	{
		public void Configure(EntityTypeBuilder<GroupEntity> builder)
		{
			builder.ToTable("groups");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.SchoolId)
				.HasColumnName("school_id")
				.IsRequired();

			builder.HasOne(x => x.School)
				.WithMany(x => x.Groups)
				.HasForeignKey(x => x.SchoolId);

			builder.HasMany(x => x.Users)
				.WithMany(x => x.Groups);
		}
	}
}