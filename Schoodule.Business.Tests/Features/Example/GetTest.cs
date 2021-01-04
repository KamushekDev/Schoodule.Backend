using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Schoodule.Business.Features.Example;
using Xunit;

namespace Schoodule.Business.Tests.Features.Example
{
	public class GetTest
	{
		private readonly Get.Validator _commandValidator;
		private readonly Mock<ILogger<Get.Handler>> _logger;

		public GetTest()
		{
			_commandValidator = new Get.Validator();
			_logger = new Mock<ILogger<Get.Handler>>();
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		public async Task GetExampleEmptyNameValidationTest(string name)
		{
			// arrange
			var command = new Get.Command(name);

			// act
			var result = await _commandValidator.ValidateAsync(command, CancellationToken.None);


			// assert
			Assert.False(result.IsValid);
			Assert.Equal(1, result.Errors.Count);
			Assert.Equal(
				"NotEmptyValidator",
				result.Errors.First()
					.ErrorCode);
		}

		[Theory]
		[InlineData("Kirill")]
		[InlineData("Complex name")]
		public async Task GetExampleTest(string name)
		{
			// arrange
			var command = new Get.Command(name);
			var handler = new Get.Handler(_logger.Object);

			// act
			var result = await handler.Handle(command, CancellationToken.None);

			// assert
			Assert.Equal($"Hello, {name}!", result.Lol);
		}
	}
}