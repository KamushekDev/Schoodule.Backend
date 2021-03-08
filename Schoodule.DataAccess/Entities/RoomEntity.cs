using System;
using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class RoomEntity
	{
		public long Id { get; set; }
		public long SchoolId { get; set; }
		public string Name { get; set; }
		public Uri Uri { get; set; }  //todo: Shound't I use string for an Entity class?

		public SchoolEntity School { get; set; }

		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();
	}
}