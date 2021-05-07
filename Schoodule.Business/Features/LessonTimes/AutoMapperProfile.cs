using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.LessonTimes
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LessonTimeEntity, LessonTime>();
		}
	}
}