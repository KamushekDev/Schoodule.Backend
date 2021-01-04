using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Schoodule.Business.Infrastructure
{
	[ExcludeFromCodeCoverage]
	public static class ServiceRegistration
	{
		/// <summary>
		/// Настраивает сервисы приложения.
		/// </summary>
		/// <param name="services">Коллекция сервисов.</param>
		/// <returns>Настроенные сервисы.</returns>>
		public static IServiceCollection AddBusiness(this IServiceCollection services)
		{
			return services;
		}
	}
}