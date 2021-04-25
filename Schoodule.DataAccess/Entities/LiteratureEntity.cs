namespace Schoodule.DataAccess.Entities
{
	public class LiteratureEntity
	{
		public long Id { get; set; }

		public string Name { get; set; }
		public string Uri { get; set; }
		
		public long LessonId { get; set; }
		public long GroupId { get; set; }
		
		public GroupEntity Group { get; set; }
		public LessonEntity Lesson { get; set; }
	}
}