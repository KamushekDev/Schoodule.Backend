using System.Linq;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Schools
{
	public static class DataSelectors
	{
		public static IQueryable<SchoolEntity> FilterAndOrder(
			this IQueryable<SchoolEntity> list,
			GetList.Command request)
		{
			if (!string.IsNullOrWhiteSpace(request.Name))
			{
				list = list.Where(
					x => x.Name.ToUpper()
						.Contains(request.Name.ToUpper()));
			}

			return list;
		}
	}
}