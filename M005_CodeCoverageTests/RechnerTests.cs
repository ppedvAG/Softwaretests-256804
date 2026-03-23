using M005_CodeCoverage;

namespace M005_CodeCoverageTests;

public class RechnerTests
{
	public DerRechner r = new DerRechner();

	[Fact]
	public void Test1()
	{
		int summe = r.Addiere(3, 4);
		Assert.Equal(7, summe);
	}
	
	[Fact]
	public void Test2()
	{
		int summe = r.Subtrahiere(3, 4);
		Assert.Equal(-1, summe);
	}
	
	[Fact]
	public void Test3()
	{
		int summe = r.Multipliziere(3, 4);
		Assert.Equal(12, summe);
	}
	
	[Fact]
	public void Test4()
	{
		double div = r.Dividiere(3, 4);
		Assert.Equal(0.75, div);
	}

	[Fact]
	public void Test5()
	{
		Assert.Throws<DivideByZeroException>(() => r.Dividiere(1, 0));
	}
}
