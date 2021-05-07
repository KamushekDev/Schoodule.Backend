using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.LessonTypes
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LessonTypeEntity, LessonType>();
		}
	}
}