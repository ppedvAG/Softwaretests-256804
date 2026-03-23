namespace BankAccount;

public interface IAccount
{
	double Balance { get; }

	void PayIn(double amount);

	void PayOut(double amount);
}