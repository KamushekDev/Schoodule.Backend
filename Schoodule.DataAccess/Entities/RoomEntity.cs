using System;

namespace Schoodule.DataAccess.Entities
{
	public class RoomEntity
	{
		public long Id { get; set; }
		public long SchoolId { get; set; }
		public string Room { get; set; }
		public Uri Uri { get; set; }
		public SchoolEntity School { get; set; }
	}
}