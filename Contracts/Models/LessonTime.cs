using NodaTime;

namespace Contract.Models
{
	public record LessonTime(long Id, string Symbol, LocalTime Time, School School);
}