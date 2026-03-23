using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Rechner_xUnit")] //Klassen/Funktion die internal sind in den Testprojekten sichtbar machen

namespace Rechner;

internal class DerRechner
{
	public int Addiere(int x, int y)
	{
		return x + y;
	}

	public int Subtrahiere(int x, int y)
	{
		return x - y;
	}

	//...
}