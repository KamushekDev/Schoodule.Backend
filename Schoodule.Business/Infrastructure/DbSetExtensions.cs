using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Schoodule.Business.Infrastructure
{
	public static class DbSetExtensions
	{
		public static ValueTask<T> FindByKeysAsync<T>(
			this DbSet<T> dbSet,
			CancellationToken token,
			params object[] keys)
			where T : class
		{
			return dbSet.FindAsync(keys, token);
		}
	}
}