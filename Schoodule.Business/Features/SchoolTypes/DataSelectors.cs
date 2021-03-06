using System.Linq;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.SchoolTypes
{
	public static class DataSelectors
	{
		public static IQueryable<SchoolTypeEntity> FilterAndOrder(
			this IQueryable<SchoolTypeEntity> list,
			GetList.Command request)
		{
			if (!string.IsNullOrWhiteSpace(request.Name))
				list = list.Where(
					x => x.Name.ToUpper()
						.Contains(request.Name.ToUpper()));
			return list;
		}
	}
}