using System.Collections.Generic;
using NodaTime;

namespace Schoodule.DataAccess.Entities
{
	public class LessonTimeEntity
	{
		public long Id { get; set; }
		public string Symbol { get; set; }
		public LocalTime Time { get; set; }
		public long SchoolId { get; set; }

		public SchoolEntity School { get; set; }

		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();
	}
}