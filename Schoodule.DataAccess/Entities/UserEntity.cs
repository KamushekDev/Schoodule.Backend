using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class UserEntity
	{
		public long UserId { get; set; }
		public string Username { get; set; }

		public ICollection<GroupEntity> Groups { get; set; }
	}
}