using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Teachers
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<TeacherEntity, Teacher>();
		}
	}
}