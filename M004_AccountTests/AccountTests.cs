using FakeItEasy;
using M004_Account;
using Moq;
using NSubstitute;

namespace M004_AccountTests;

/// <summary>
/// Mocking
/// Allows for fast/efficient creation of Mock-Classes
/// NuGet: Moq, NSubstitute, FakeItEasy
/// </summary>
public class AccountTests
{
	/// <summary>
	/// This method simulates a database access
	/// With Moq we can abstract the real db access away (no db access at all)
	/// </summary>
	[Fact]
	public void Test1()
	{
		//Arrange
		Mock<IAccount> mock = new Mock<IAccount>(); //Creates the Mock Container
		mock.Setup(m => m.PayIn(50)) //When PayIn is called,
			.Returns(50); //then the method should return 50

		//Act
		double d = mock.Object.PayIn(50); //In the Setup Process (above), the Code for this Method gets defined
		//double d2 = mock.Object.PayIn(50);

		//Assert
		//Assert.Equal(50, d);
		mock.Verify(m => m.PayIn(50), Moq.Times.Once); //Was PayIn(50) called exactly once?
	}

	/// <summary>
	/// NSubstitute
	/// </summary>
	[Fact]
	public void Test2()
	{
		//Arrange
		IAccount a = Substitute.For<IAccount>(); //Create the object like Moq
		a.PayIn(50).Returns(50);

		//Act
		double d = a.PayIn(50);

		//Assert
		Assert.Equal(50, d);
	}

	/// <summary>
	/// FakeItEasy
	/// </summary>
	[Fact]
	public void Test3()
	{
		//Arrange
		IAccount a = A.Fake<IAccount>(); //Create the object like Moq
		A.CallTo(() => a.PayIn(50)).Returns(50);

		//Act
		double d = a.PayIn(50);

		//Assert
		Assert.Equal(50, d);
	}
}
