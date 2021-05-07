namespace Contract.Models
{
	public record Teacher(
		long Id,
		string Firstname,
		string Lastname,
		string Patronymic,
		string Email,
		string Phone);
}