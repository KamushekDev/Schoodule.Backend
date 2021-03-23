using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Schoodule.API.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Schoodule.API.Extensions
{
	public static class SwaggerExtensions
	{
		public static void AddConfiguredSwagger(this IServiceCollection services)
		{
			services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
			services.AddSwaggerGen(
				options =>
				{
					// add a custom operation filter which sets default values
					options.OperationFilter<SwaggerDefaultValues>();

					options.CustomSchemaIds(
						type =>
						{
							var sb = new StringBuilder();
							var currentType = type;

							while (currentType is not null)
							{
								sb.Insert(0, currentType.Name);
								currentType = currentType.DeclaringType;
							}

							if (type.IsNested && type.Namespace is not null)
								sb.Insert(0, type.Namespace.Substring(type.Namespace.LastIndexOf('.')+1));

							return sb.ToString();
						});

					// integrate xml comments
					// var basePath = PlatformServices.Default.Application.ApplicationBasePath;
					// var fileName = typeof(Startup).GetTypeInfo()
					// 	               .Assembly.GetName()
					// 	               .Name +
					//                ".xml";
					// var xmlFilePath =  Path.Combine(basePath, fileName);
					// options.IncludeXmlComments(xmlFilePath);
				});
		}

		// ReSharper disable once InconsistentNaming
		// Looks good to leave UI capitalized
		public static void UseConfiguredSwaggerUI(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
		{
			app.UseSwagger();
			app.UseSwaggerUI(
				options =>
				{
					// build a swagger endpoint for each discovered API version
					foreach (var description in provider.ApiVersionDescriptions)
					{
						options.SwaggerEndpoint(
							$"/swagger/{description.GroupName}/swagger.json",
							description.GroupName.ToUpperInvariant());
					}
				});
		}
	}
}