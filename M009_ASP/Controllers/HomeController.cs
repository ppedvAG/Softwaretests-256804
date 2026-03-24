using M009_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace M009_ASP.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
	[FromQuery]
	public int Counter { get; set; }

	public IActionResult Index()
	{
		return View(Counter);
	}

	public IActionResult CounterPlusPlus(int n)
	{
		return RedirectToAction("Index", new { Counter = n + 1 });
	}


	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
