namespace M005_CodeCoverage;

public class DerRechner
{
	public int Addiere(int x, int y)
	{
		return x + y;
	}

	public int Subtrahiere(int x, int y)
	{
		return x - y;
	}

	public int Multipliziere(int x, int y)
	{
		return x * y;
	}

	public double Dividiere(int x, int y)
	{
		if (y == 0)
			throw new DivideByZeroException();
		return (double) x / y;
	}
}