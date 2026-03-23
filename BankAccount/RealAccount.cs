namespace BankAccount;

/// <summary>
/// Here we implement the real code
/// </summary>
public class RealAccount : IAccount
{
	public double Balance { get; private set; }

	public void PayIn(double amount)
	{
		if (amount < 0)
			throw new ArgumentException("Amount cannot be less than 0");

		Balance += amount;
	}

	public void PayOut(double amount)
	{
		if (amount < 0)
			throw new ArgumentException("Amount cannot be less than 0");

		Balance -= amount;
	}
}