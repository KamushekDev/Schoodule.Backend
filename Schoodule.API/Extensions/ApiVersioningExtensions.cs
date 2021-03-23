using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Schoodule.API.Extensions
{
	public static class ApiVersioningExtensions
	{
		public static void AddConfiguredVersioning(this IServiceCollection services)
		{
			var versionReader = new HeaderApiVersionReader("version");

			services.AddApiVersioning(
				options =>
				{
					options.ReportApiVersions = true;
					options.ApiVersionReader = versionReader;
				});
			services.AddVersionedApiExplorer(
				options =>
				{
					options.GroupNameFormat = "'v'VVV";
					options.ApiVersionParameterSource = versionReader;
				});
		}
	}
}