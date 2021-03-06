using System.Collections.Generic;

namespace Schoodule.DataAccess.Entities
{
	public class SchoolEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public SchoolTypeEntity SchoolType { get; set; }
		public long SchoolTypeId { get; set; }
		public ICollection<GroupEntity> Groups { get; set; } = new List<GroupEntity>();
		public ICollection<LessonEntity> Lessons { get; set; } = new List<LessonEntity>();
		public ICollection<RoomEntity> Rooms { get; set; } = new List<RoomEntity>();
		public ICollection<TeacherEntity> Teachers { get; set; } = new List<TeacherEntity>();
		public ICollection<LessonTypeEntity> LessonTypes { get; set; } = new List<LessonTypeEntity>();
		public ICollection<LessonTimeEntity> LessonTimes { get; set; } = new List<LessonTimeEntity>();
	}
}