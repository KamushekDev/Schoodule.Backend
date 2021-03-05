namespace Schoodule.DataAccess.Entities
{
	public class LessonEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long SchoolId { get; set; }
		public SchoolEntity School { get; set; }
	}
}