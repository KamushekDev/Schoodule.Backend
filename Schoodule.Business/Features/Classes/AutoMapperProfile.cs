using System;
using Contract.Models;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Classes
{
	public class AutoMapperProfile : AutoMapper.Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ClassEntity, Class>()
				.ForCtorParam(
					nameof(Class.LessonName),
					entity => entity.MapFrom(x => x.Lesson.Name))
				.ForCtorParam(
					nameof(Class.LessonTypeName),
					entity => entity.MapFrom(x => x.LessonType.Name))
				.ForCtorParam(
					nameof(Class.LessonStartTimeHour),
					entity => entity.MapFrom(x => x.LessonTime.Hours))
				.ForCtorParam(
					nameof(Class.LessonStartTimeMinute),
					entity => entity.MapFrom(x => x.LessonTime.Minutes))
				.ForCtorParam(
					nameof(Class.LessonEndTimeHour),
					entity => entity.MapFrom(x => x.LessonTime.EndTime.Hours))
				.ForCtorParam(
					nameof(Class.LessonEndTimeMinute),
					entity => entity.MapFrom(x => x.LessonTime.EndTime.Minutes))
				.ForCtorParam(
					nameof(Class.SchoolName),
					entity => entity.MapFrom(x => x.School.Name))
				.ForCtorParam(
					nameof(Class.GroupName),
					entity => entity.MapFrom(x => x.Group.Name))
				.ForCtorParam(
					nameof(Class.TeacherFirstname),
					entity => entity.MapFrom(x => x.Teacher.Firstname))
				.ForCtorParam(
					nameof(Class.TeacherLastname),
					entity => entity.MapFrom(x => x.Teacher.Lastname))
				.ForCtorParam(
					nameof(Class.TeacherPatronymic),
					entity => entity.MapFrom(x => x.Teacher.Patronymic))
				.ForCtorParam(
					nameof(Class.RoomName),
					entity => entity.MapFrom(x => x.Room.Name))
				.ForCtorParam(
					nameof(Class.RoomUri),
					entity => entity.MapFrom(x => x.Room.Uri))
				.ForCtorParam(
					nameof(Class.RoomIsRemote),
					entity => entity.MapFrom(x => x.Room.Uri != null));
		}
	}
}