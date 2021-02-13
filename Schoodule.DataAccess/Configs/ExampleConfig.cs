using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class ExampleConfig : IEntityTypeConfiguration<ExampleEntity>
	{
		public void Configure(EntityTypeBuilder<ExampleEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();
			builder.HasIndex(x => x.Name)
				.IsUnique();
			builder.Property(x => x.Name)
				.HasMaxLength(1024)
				.IsRequired();
			builder.Property(x => x.NickName)
				.HasMaxLength(1024);
			builder.Property(x => x.Type)
				.IsRequired();
		}
	}
}