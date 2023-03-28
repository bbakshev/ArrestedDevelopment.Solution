using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArrestedDevelopmentClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArrestedDevelopmentClient.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }
  public async Task<IActionResult> Index()
  {
    List<Quote> quoteList = new List<Quote> { };
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync("https://localhost:5001/api/Quotes"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        JObject jsonResponse = JObject.Parse(apiResponse);
        JArray quoteArray = (JArray)jsonResponse["data"];
        quoteList = quoteArray.ToObject<List<Quote>>();
      }
    }
    return View(quoteList);
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
