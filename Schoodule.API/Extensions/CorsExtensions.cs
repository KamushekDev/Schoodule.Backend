using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Schoodule.API.Extensions
{
	public static class CorsExtensions
	{
		private const string DebugPolicy = "DEBUG";
		private const string ProductionPolicy = "PRODUCTION";
		private const string DefaultHost = "https://localhost:*";

		public static void AddConfiguredCors(this IServiceCollection services, IConfiguration configuration)
		{
			//todo: url
			var webUri = configuration["WEB_URI"] ?? DefaultHost;

			services.AddCors(
				options =>
				{
					options.AddPolicy(
						DebugPolicy,
						builder =>
						{
							builder.AllowAnyOrigin()
								.AllowAnyMethod()
								.AllowAnyHeader();
						});
					options.AddPolicy(
						ProductionPolicy,
						builder =>
						{
							builder.WithOrigins(webUri)
								.AllowAnyHeader()
								.AllowAnyMethod();
						});
				});
		}

		public static void UseConfiguredCors(this IApplicationBuilder app, IConfiguration configuration)
		{
			var corsPolicy = configuration["CORS_POLICY"];

			switch (corsPolicy)
			{
				case DebugPolicy:
					app.UseCors(DebugPolicy);
					break;
				case ProductionPolicy:
					app.UseCors(ProductionPolicy);
					break;
				default:
					//todo: fix exception
					throw new Exception("Unexpected CORS policy.");
					break;
			}
		}
	}
}