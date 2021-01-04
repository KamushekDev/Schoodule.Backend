using System.Linq;
using System.Text.Json.Serialization;
using FluentValidation;
using MediatR;
using MediatR.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schoodule.API.Infrastructure;
using Schoodule.Business;
using Schoodule.Business.Infrastructure;

namespace Schoodule.API
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHealthChecks();
			services.AddSwaggerGen();
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

			services.AddMediatR(typeof(BusinessLayer));
			services.Scan(
				scan => scan
					.FromAssembliesOf(typeof(Startup), typeof(BusinessLayer))
					.AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
					.As(
						type => type.GetInterfaces()
							.Where(
								i => i.IsGenericType &&
								     !i.IsOpenGeneric() &&
								     i.GetGenericTypeDefinition() == typeof(IValidator<>)))
					.WithTransientLifetime());

			services.AddBusiness();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Schoodule v1"); });
			app
				.UseRouting()
				.UseEndpoints(routeBuilder => { routeBuilder.MapControllers(); });
		}
	}
}