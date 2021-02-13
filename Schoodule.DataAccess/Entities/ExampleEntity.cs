using Schoodule.DataAccess.Enums;

namespace Schoodule.DataAccess.Entities
{
	public class ExampleEntity
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string NickName { get; set; }
		public ExampleType Type { get; set; }
	}
}