namespace M004_Account;

public interface IAccount
{
	double Balance { get; }

	/// <summary>
	/// Here is a Database access behind
	/// </summary>
	double PayIn(double amount);

	/// <summary>
	/// Here is a Database access behind
	/// </summary>
	double PayOut(double amount);
}