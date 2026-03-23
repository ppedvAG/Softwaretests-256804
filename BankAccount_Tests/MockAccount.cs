using BankAccount;

namespace BankAccount_Tests;

/// <summary>
/// Very simple implementation, that gets replaced later with the real implementation
/// </summary>
internal class MockAccount : IAccount
{
	public double Balance { get; private set; }

	public void PayIn(double amount)
	{
		Balance += amount;
	}

	public void PayOut(double amount)
	{
		Balance -= amount;
	}
}
