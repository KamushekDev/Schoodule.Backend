using System;
using Microsoft.AspNetCore.Http;

namespace Schoodule.Core.Exceptions
{
	public class EntityNotFoundException : UserException
	{
		public EntityNotFoundException(string message) : base(StatusCodes.Status404NotFound, message) { }

		public EntityNotFoundException(string message, Exception innerException) : base(
			StatusCodes.Status404NotFound,
			message,
			innerException) { }
	}
}