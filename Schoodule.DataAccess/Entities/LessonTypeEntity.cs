using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class LessonTypeEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long SchoolId { get; set; }

		public SchoolEntity School { get; set; }

		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();
	}
}