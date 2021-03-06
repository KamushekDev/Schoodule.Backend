using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class GroupEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long SchoolId { get; set; }

		public SchoolEntity School { get; set; }

		public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();
	}
}