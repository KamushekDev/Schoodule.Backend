using System;
using Microsoft.AspNetCore.Http;

namespace Schoodule.Core.Exceptions
{
	public class EntityNotFoundException : UserException
	{
		public EntityNotFoundException(string message) : base(StatusCodes.Status200OK, message) { }

		public EntityNotFoundException(string message, Exception innerException) : base(
			StatusCodes.Status200OK,
			message,
			innerException) { }
	}
}