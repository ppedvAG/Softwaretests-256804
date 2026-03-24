using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M009_WPF_Tests
{
	[TestClass]
	public class UnitTest1
	{
		/// <summary>
		/// FlaUI.Core
		/// FlaUI.UIA3
		/// </summary>
		[TestMethod]
		public void TestMethod1()
		{
			string path = @"C:\Users\lk3\source\repos\Softwaretests_2026_03_23\M009_WPF\bin\Debug\net9.0-windows\M009_WPF.exe";
			Application a = Application.Launch(path);

			Window w = a.GetMainWindow(new UIA3Automation());

			Label output = w.FindFirstDescendant(e => e.ByText("Hello")).AsLabel();

			Button b = w.FindFirstDescendant(e => e.ByText("Test")).AsButton();

			b.Click();
			b.Click();
			b.Click();
			b.Click();

			string text = output.Text;

			Assert.AreEqual("Counter: 4", text);

			w.Close();
		}
	}
}
