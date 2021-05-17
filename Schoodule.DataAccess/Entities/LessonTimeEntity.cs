using System;
using System.Collections.Generic;
using NodaTime;

namespace Schoodule.DataAccess.Entities
{
	public class LessonTimeEntity
	{
		public long Id { get; set; }
		public string Symbol { get; set; }
		public int Hours { get; set; }
		public int Minutes { get; set; }
		public int Duration { get; set; }

		public long SchoolId { get; set; }

		public SchoolEntity School { get; set; }

		public ICollection<ClassEntity> Classes { get; set; } = new List<ClassEntity>();

		public TimeSpan EndTime => new TimeSpan(Hours, Minutes, 0).Add(new TimeSpan(0, Duration, 0));
	}
}