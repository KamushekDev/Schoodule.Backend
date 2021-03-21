using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class SchoolTypeEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public ICollection<SchoolEntity> Schools { get; set; } = new List<SchoolEntity>();
	}
}