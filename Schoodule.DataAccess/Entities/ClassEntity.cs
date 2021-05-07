using Schoodule.Core.Enums;

namespace Schoodule.DataAccess.Entities
{
	public class ClassEntity
	{
		public long Id { get; set; }
		public string Description { get; set; }
		public Weekday Weekday { get; set; }
		public WeekType WeekType { get; set; }

		public long LessonId { get; set; }
		public long LessonTypeId { get; set; }
		public long LessonTimeId { get; set; }
		public long SchoolId { get; set; }
		public long TeacherId { get; set; }
		public long GroupId { get; set; }
		public long RoomId { get; set; }

		public LessonEntity Lesson { get; set; }
		public LessonTypeEntity LessonType { get; set; }
		public LessonTimeEntity LessonTime { get; set; }
		public SchoolEntity School { get; set; }
		public TeacherEntity Teacher { get; set; }
		public GroupEntity Group { get; set; }
		public RoomEntity Room { get; set; }
	}
}