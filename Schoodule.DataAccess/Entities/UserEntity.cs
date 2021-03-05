using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class UserEntity
	{
		public long Id { get; set; }
		public string Username { get; set; }

		public ICollection<GroupEntity> Groups { get; set; } = new List<GroupEntity>();
	}
}