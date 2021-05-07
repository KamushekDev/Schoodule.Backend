using Schoodule.Core.Enums;

namespace Contract.Models
{
	public record Class(
		long Id,
		string Description,
		string LessonName,
		string LessonTypeName,
		int LessonTimeHour,
		int LessonTimeMinute,
		int LessonTimeDuration,
		string SchoolName,
		string TeacherFirstname,
		string TeacherLastname,
		string TeacherPatronymic,
		string GroupName,
		string RoomName,
		string RoomUri,
		bool RoomIsRemote,
		WeekType WeekType
	);
}