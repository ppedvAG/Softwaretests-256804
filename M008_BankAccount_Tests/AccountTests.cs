using M008_BankAccount;

namespace M008_BankAccount_Tests;

public class AccountTests
{
	/// <summary>
	/// Mock
	/// 
	/// A placeholder class, that is used for testing here
	/// Gets replaced later with the real code
	/// Should always inherit from an interface
	/// </summary>
	[Fact]
	public void Account_PayIn50_Result50()
	{
		IAccount mockAccount = new RealAccount(); //After defining the real code, replace MockAccount with (Real)Account
		mockAccount.PayIn(50);
		Assert.Equal(50, mockAccount.Balance);
	}

	[Fact]
	public void Account_PayOut50_ResultNegative50()
	{
		IAccount mockAccount = new MockAccount(); //Replace here as well
		mockAccount.PayOut(50);
		Assert.Equal(-50, mockAccount.Balance);
	}

	[Fact]
	public void Account_New_Result0()
	{
		IAccount mockAccount = new MockAccount(); //Replace here as well
		Assert.Equal(0, mockAccount.Balance);
	}
}
