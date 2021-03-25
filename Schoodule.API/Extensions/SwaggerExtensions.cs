using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Schoodule.API.Infrastructure;
using Schoodule.Business.Attributes;
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
							var typeAttributes = type.GetCustomAttributes(typeof(SwaggerSchemaIdAttribute), false);

							if (typeAttributes.Any())
								return ((SwaggerSchemaIdAttribute) typeAttributes[0]).SchemaId;

							return type.FriendlyId(true);
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

		/// <remarks>Taken from <see href="https://raw.githubusercontent.com/domaindrivendev/Swashbuckle.WebApi/master/Swashbuckle.Core/Swagger/TypeExtensions.cs"/></remarks>
		public static string FriendlyId(this Type type, bool fullyQualified = false)
		{
			var typeName = fullyQualified
				? type.FullNameSansTypeParameters()
					.Replace("+", ".")
				: type.Name;

			if (type.IsGenericType)
			{
				var genericArgumentIds = type.GetGenericArguments()
					.Select(t => t.FriendlyId(fullyQualified))
					.ToArray();

				return new StringBuilder(typeName)
					.Replace($"`{genericArgumentIds.Length}", string.Empty)
					.Append($"[{string.Join(",", genericArgumentIds).TrimEnd(',')}]")
					.ToString();
			}

			return typeName;
		}

		/// <remarks>Taken from <see href="https://raw.githubusercontent.com/domaindrivendev/Swashbuckle.WebApi/master/Swashbuckle.Core/Swagger/TypeExtensions.cs"/></remarks>
		public static string FullNameSansTypeParameters(this Type type)
		{
			var fullName = type.FullName;
			if (string.IsNullOrEmpty(fullName))
				fullName = type.Name;
			var chopIndex = fullName.IndexOf("[[");
			return (chopIndex == -1) ? fullName : fullName.Substring(0, chopIndex);
		}
	}
}