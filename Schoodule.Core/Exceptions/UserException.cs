using System;
using System.Runtime.Serialization;

namespace Schoodule.Core.Exceptions
{
	[Serializable]
	public class UserException : ApplicationException
	{
		public UserException(
			int statusCode,
			string message = null,
			Exception innerException = null)
			: base(message, innerException)
		{
			StatusCode = statusCode;
		}

		public UserException(string message, Exception innerException)
			: base(message, innerException) { }

		public UserException(string message)
			: base(message) { }

		public UserException() { }

		protected UserException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }

		public int StatusCode { get; init; }
	}
}