using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schoodule.API.Extensions;
using Schoodule.API.Infrastructure;
using Schoodule.Business;
using Schoodule.Business.Infrastructure;
using Schoodule.DataAccess;

namespace Schoodule.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			Environment = env;
		}

		public IConfiguration Configuration { get; }

		public IWebHostEnvironment Environment { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			var dbConnectionString = Configuration["POSTGRESQLCONNSTR_DB"];

			services.AddHealthChecks()
				.AddNpgSql(dbConnectionString)
				.AddDbContextCheck<AppDbContext>();

			services.AddControllers(options => { options.Filters.Add<ApiErrorFilter>(); })
				.AddJsonOptions(
					options =>
					{
#if DEBUG
						options.JsonSerializerOptions.WriteIndented = true;
#endif
						options.JsonSerializerOptions.IgnoreNullValues = true;
						options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
					});

			services.AddConfiguredVersioning();

			services.AddConfiguredSwagger();

			services.AddDbContext<AppDbContext>(
				options => options.UseNpgsql(
					dbConnectionString,
					sql => sql.UseNodaTime()));

			services.AddAutoMapper(typeof(BusinessLayer).Assembly);

			services.AddConfiguredMediatR();

			services.AddBusiness();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
		{
			app.UseDeveloperExceptionPage();
			if (env.IsDevelopment()) { }

			app
				.UseRouting()
				.UseEndpoints(
					endpoints =>
					{
						endpoints.MapControllers();
						endpoints.MapHealthChecks(
							"/health/ready",
							new HealthCheckOptions
							{
								Predicate = check => check.Tags.Contains("ready")
							});
						endpoints.MapHealthChecks("/health/live", new HealthCheckOptions());
						endpoints.MapGet(
							"/",
							context =>
							{
								context.Response.Redirect("/swagger");
								return Task.CompletedTask;
							});
					});
			app.UseConfiguredSwaggerUI(provider);
		}
	}
}