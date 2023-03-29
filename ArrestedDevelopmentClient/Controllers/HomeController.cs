using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArrestedDevelopmentClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ArrestedDevelopmentClient.Controllers;
[Authorize]
public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }
  [AllowAnonymous]
  public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
  {
    List<Quote> quoteList = new List<Quote> { };
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync($"https://localhost:5001/api/Quotes?question=false&page={page}&pageSize={pageSize}"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        JObject jsonResponse = JObject.Parse(apiResponse);
        JArray quoteArray = (JArray)jsonResponse["data"];
        quoteList = quoteArray.ToObject<List<Quote>>();
      }
    }
    List<Quote> quoteList2 = new List<Quote> { };
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync("https://localhost:5001/api/Quotes?question=false&page=1&pageSize=1001"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        JObject jsonResponse = JObject.Parse(apiResponse);
        JArray quoteArray = (JArray)jsonResponse["data"];
        quoteList2 = quoteArray.ToObject<List<Quote>>();
      }
    }
    ViewBag.LastId = quoteList2.Count();
    ViewBag.CurrentPage = page;
    ViewBag.PageSize = pageSize;
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

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Quote quote)
  {
    Quote.Post(quote);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Quote quote = Quote.GetDetails(id);
    return View(quote);
  }

  [HttpPost]
  public ActionResult Edit(Quote quote)
  {
    Quote.Put(quote);
    return RedirectToAction("Index");
  }
}
