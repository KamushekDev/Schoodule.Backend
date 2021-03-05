using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoodule.DataAccess.Entities;

namespace Schoodule.DataAccess.Configs
{
	public class RoomConfig : IEntityTypeConfiguration<RoomEntity>
	{
		public void Configure(EntityTypeBuilder<RoomEntity> builder)
		{
			builder.ToTable("rooms");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.SchoolId)
				.HasColumnName("school_id")
				.IsRequired();
			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(x => x.Room)
				.HasColumnName("room")
				.HasMaxLength(100);
			builder.Property(x => x.Uri)
				.HasColumnName("uri")
				.HasMaxLength(300);

			builder.HasOne(x => x.School)
				.WithMany(x => x.Rooms)
				.HasForeignKey(x => x.SchoolId);
		}
	}
}