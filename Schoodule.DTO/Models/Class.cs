using Contract.Enums;

namespace Contract.Models
{
	public record Class(
		long Id,
		string Description,
		Lesson Lesson,
		LessonType LessonType,
		LessonTime LessonTime,
		School School,
		Teacher Teacher,
		Group Group,
		Room Room,
		WeekType WeekType
	);
}