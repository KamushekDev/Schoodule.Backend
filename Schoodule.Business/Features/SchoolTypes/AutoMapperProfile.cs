using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.SchoolTypes
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<SchoolTypeEntity, SchoolType>();
			CreateMap<SchoolType, SchoolTypeEntity>();
		}
	}
}