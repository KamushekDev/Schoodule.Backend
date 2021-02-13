using System;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;

namespace Schoodule.Business.Tests
{
	public static class MockHelper
	{
		public static AppDbContext CreateInMemoryDbContext()
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseInMemoryDatabase($"notif_{Guid.NewGuid()}");
			var appDbContext = new AppDbContext(optionsBuilder.Options);

			SeedDatabase(appDbContext);

			return appDbContext;
		}

		private static void SeedDatabase(AppDbContext db)
		{
			//todo: seed database for example
			db.SaveChanges();
		}
	}
}