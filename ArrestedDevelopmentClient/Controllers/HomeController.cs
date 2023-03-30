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
      using (var response = await httpClient.GetAsync($"http://localhost:5000/api/Quotes?question=false&page={page}&pageSize={pageSize}"))
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
      using (var response = await httpClient.GetAsync("http://localhost:5000/api/Quotes?question=false&page=1&pageSize=1001"))
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

  public async Task<ActionResult> LoadEdit(int id)
  {
    List<Quote> quoteList = new List<Quote> { };
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync($"http://localhost:5000/api/Quotes?id={id}"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        JObject jsonResponse = JObject.Parse(apiResponse);
        JArray quoteArray = (JArray)jsonResponse["data"];
        quoteList = quoteArray.ToObject<List<Quote>>();
      }
    }
    Quote quote = quoteList[0];
    return RedirectToAction("Edit", quote);
  }

  public ActionResult Edit(Quote quote)
  {
    return View(quote);
  }

  [HttpPost, ActionName("Edit")]
  public ActionResult PutEdit(Quote quote)
  {
    Quote.Put(quote);
    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id, int currentPage)
  {
    Quote quote = Quote.GetDetails(id);
    ViewBag.CurrentPage = currentPage;
    return View(quote);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id, int currentPage)
  {
    Quote.Delete(id);
    return RedirectToAction("Index", new { page = currentPage, pageSize = 10 } );
  }
}