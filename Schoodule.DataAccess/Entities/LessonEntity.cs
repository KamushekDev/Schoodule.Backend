using System.Collections.Generic;
using Schoodule.DataAccess.Enums;

namespace Schoodule.DataAccess.Entities
{
	public class LessonEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long SchoolId { get; set; }
		public WeekType WeekType { get; set; }

		public SchoolEntity School { get; set; }

		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();
	}
}