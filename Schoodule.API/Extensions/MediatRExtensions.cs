using System.Linq;
using FluentValidation;
using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;
using Schoodule.Business;

namespace Schoodule.API.Extensions
{
	public static class MediatRExtensions
	{
		public static void AddConfiguredMediatR(this IServiceCollection services)
		{
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
		}
	}
}