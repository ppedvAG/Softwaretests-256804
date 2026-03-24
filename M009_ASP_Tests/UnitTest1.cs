using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace M009_ASP_Tests;

public class UnitTest1
{
	/// <summary>
	/// Selenium.WebDriver
	/// Selenium.Firefox.WebDriver
	/// </summary>
	[Fact]
	public void Test1()
	{
		FirefoxOptions browser = new FirefoxOptions();
		browser.AddArguments("--headless"); //Hide the browser from the user

		FirefoxDriver driver = new FirefoxDriver(browser);

		driver.Navigate().GoToUrl("http://localhost:5000");

		driver.FindElements(By.TagName("button"))[2].Click();
		string content = driver.FindElements(By.TagName("p"))[1].Text;

		Assert.Equal("1", content);

		driver.Close();
	}
}
