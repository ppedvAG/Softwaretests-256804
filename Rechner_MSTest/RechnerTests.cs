using Rechner;

namespace Rechner_MSTest;

/// <summary>
/// Schritt 1: Abhängigkeit zum Hauptprojekt herstellen
/// Schritt 2: Test schreiben
/// Schritt 3: Test Explorer öffnen -> Tests ausführen
/// </summary>
[TestClass]
public sealed class RechnerTests
{
	DerRechner r;

	/// <summary>
	/// TestInitialize: Wird vor allen Tests ausgeführt
	/// </summary>
	[TestInitialize]
	public void Setup()
	{
		r = new DerRechner();
	}

	[TestCleanup]
	public void Cleanup()
	{
		r = null;
	}

	////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// CCC: Code, Condition, Conclusion
	/// </summary>
	[TestMethod]
	[TestCategory("Addition")]
	[TestCategory("Rechner")]
	public void Addiere_3und4_Ergebnis7()
	{
		//AAA

		//Arrange
		//DerRechner r = new DerRechner();

		//Act
		int ergebnis = r.Addiere(3, 4);

		//Assert
		Assert.AreEqual(7, ergebnis);
	}

	/// <summary>
	/// DataRow: Mehrere verschiedene Datenpunkte testen
	/// Muss mit Methodenparametern ergänzt werden (x, y, result)
	/// </summary>
	[TestMethod]
	[DataRow(5, 2, 3)]
	[DataRow(10, 3, 7)]
	[DataRow(3, 5, -2)]
	[TestCategory("Subtraktion")]
	public void Subtrahiere_MehrereDaten_MehrereErgebisse(int x, int y, int result)
	{
		//AAA
		//DerRechner r = new DerRechner();
		int differenz = r.Subtrahiere(x, y);
		Assert.AreEqual(result, differenz);
	}
}