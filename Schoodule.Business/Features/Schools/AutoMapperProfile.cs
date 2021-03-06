using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Schools
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<SchoolEntity, School>();
			CreateMap<School, SchoolEntity>();
		}
	}
}