using System.Linq;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Lessons
{
	public static class DataSelectors
	{
		public static IQueryable<LessonEntity> FilterAndOrder(
			this IQueryable<LessonEntity> list,
			GetList.Command request)
		{
			if (request.Name is not null)
			{
				list = list.Where(
					x => x.Name.ToUpper()
						.Contains(request.Name.ToUpper()));
			}

			return list;
		}
	}
}