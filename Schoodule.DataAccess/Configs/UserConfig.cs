using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class UserConfig : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.ToTable("uses");
			builder.HasKey(x => x.UserId);

			builder.Property(x => x.UserId)
				.HasColumnName("user_id")
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(x => x.Username)
				.HasColumnName("username")
				.IsRequired()
				.HasMaxLength(100);

			builder.HasMany(x => x.Groups)
				.WithMany(x => x.Users);
		}
	}
}