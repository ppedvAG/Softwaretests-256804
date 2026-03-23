using Rechner;
using System.Collections;

namespace Rechner_xUnit;

public class RechnerTests
{
	[Fact]
	[Trait("Category", "Addition")]
	public void Addiere_3und4_Ergebnis7()
	{
		//Arrange
		DerRechner r = new DerRechner();

		//Act
		int ergebnis = r.Addiere(3, 4);

		//Assert
		Assert.Equal(7, ergebnis);
	}

	[Theory] //Theory: Test, mit mehreren Datenpunkten
	[InlineData(5, 2, 3)]
	[InlineData(10, 3, 7)]
	[InlineData(3, 5, -2)]
	public void Subtrahiere_MehrereDaten_MehrereErgebisse(int x, int y, int result)
	{
		//AAA
		DerRechner r = new DerRechner();
		int differenz = r.Subtrahiere(x, y);
		Assert.Equal(result, differenz);
	}

	[Theory]
	[ClassData(typeof(ExternData))] //ClassData: Daten aus einer externen Quelle testen (z.B. File)
	public void Sum_Data(int x, int y, int result)
	{

	}
}

/// <summary>
/// Hier wird eine separate Klasse definiert, die die Daten lädt und hält
/// </summary>
public class ExternData : IEnumerable<object[]>
{
	public ExternData()
	{
		File.ReadAllText("..."); //Externe Daten lesen
		//Data = ...  //Diese Daten in die Data-Liste hineinlegen
	}

	public readonly List<object[]> Data = []; //Hier MUSS eine List<object[]> namens Data erstellt

	////////////////////////////////////////////////////////////////

	public IEnumerator<object[]> GetEnumerator() => Data.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}