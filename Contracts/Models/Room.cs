namespace Contract.Models
{
	public record Room(long Id, string Name, string Uri, bool IsRemote, School School);
}