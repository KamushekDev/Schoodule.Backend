namespace Contract.Models
{
	public class School
	{
		public string Name { get; set; }
		public long SchoolTypeId { get; set; }
		public SchoolType Type { get; set; }
	}
}