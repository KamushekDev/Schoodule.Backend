using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class TeacherEntity
	{
		public long Id { get; set; }
		public long SchoolId { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Patronymic { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }

		public SchoolEntity School { get; set; }

		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();
	}
}