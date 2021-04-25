using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ClassEntity, Class>();
			CreateMap<GroupEntity, Group>();
			CreateMap<LessonEntity, Lesson>();
			CreateMap<LessonTimeEntity, LessonTime>();
			CreateMap<LessonTypeEntity, LessonType>();
			CreateMap<RoomEntity, Room>()
				.ForCtorParam(
					nameof(Room.IsRemote),
					x => x.MapFrom(re => re.Uri != null));
			CreateMap<SchoolEntity, School>();
			CreateMap<SchoolTypeEntity, SchoolType>();
			CreateMap<TeacherEntity, Teacher>();
			CreateMap<LiteratureEntity, Literature>();
		}
	}
}