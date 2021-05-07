using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Lessons
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LessonEntity, Lesson>();
		}
	}
}