using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Rooms
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<RoomEntity, Room>()
				.ForCtorParam(
					nameof(Room.IsRemote),
					x => x.MapFrom(re => re.Uri != null))
				.ForCtorParam(
					nameof(Room.SchoolName),
					x => x.MapFrom(re => re.School.Name));
		}
	}
}