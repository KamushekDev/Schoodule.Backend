using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Example
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ExampleEntity, Example>()
				.ForMember(x => x.NickName, mo => mo.MapFrom(x => x.NickName))
				.ForMember(x => x.Name, mo => mo.MapFrom(x => x.Name))
				.ForMember(x => x.Type, mo => mo.MapFrom(x => x.Type));
		}
	}
}