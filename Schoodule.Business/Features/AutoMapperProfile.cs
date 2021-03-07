using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LessonTimeEntity, LessonTime>();

			CreateMap<GroupEntity, Group>();

			CreateMap<LessonEntity, Lesson>();

			CreateMap<SchoolEntity, School>();

			CreateMap<SchoolTypeEntity, SchoolType>();

			CreateMap<LessonTypeEntity, LessonType>();
		}
	}
}