namespace Schoodule.DataAccess.Entities
{
	public class GroupEntity
	{
		public long GroupId { get; set; }
		public string Name { get; set; }
		public long SchoolId { get; set; }
		public SchoolEntity School { get; set; }
	}
}