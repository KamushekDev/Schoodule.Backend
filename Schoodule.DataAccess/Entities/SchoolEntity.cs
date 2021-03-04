using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class SchoolEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public SchoolTypeEntity SchoolType { get; set; }
		public long SchoolTypeId { get; set; }
		public ICollection<GroupEntity> Groups { get; set; } = new List<GroupEntity>();
	}
}