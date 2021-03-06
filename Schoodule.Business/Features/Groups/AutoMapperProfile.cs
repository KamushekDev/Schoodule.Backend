using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Groups
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<GroupEntity, Group>();
			CreateMap<Group, GroupEntity>();
		}
	}
}