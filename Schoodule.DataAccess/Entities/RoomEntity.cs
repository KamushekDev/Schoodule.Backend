using System;
using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class RoomEntity
	{
		public long Id { get; set; }
		public long SchoolId { get; set; }
		public string Name { get; set; }
		public Uri Uri { get; set; }

		public SchoolEntity School { get; set; }

		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();
	}
}