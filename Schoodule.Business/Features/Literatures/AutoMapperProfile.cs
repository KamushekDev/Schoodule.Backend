using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Literatures
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LiteratureEntity, Literature>();
		}
	}
}