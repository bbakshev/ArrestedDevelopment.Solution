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


  // apiResponse = "{\"data\":[{\"quoteId\":2,\"speaker\":\"Unknown\",\"text\":\"You boys know how to shovel coal?\",\"numberOfWords\":7},{\"quoteId\":3,\"speaker\":\"Buster\",\"text\":\"What do you expect, Mother? I'm half machine!\",\"numberOfWords\":8},{\"quoteId\":4,\"speaker\":\"Buster\",\"text\":\"I'm a monster!\",\"numberOfWords\":3},{\"quoteId\":5,\"speaker\":\"Unknown\",\"text\":\"It's a good thing he's already got that little scooter\",\"numberOfWords\":10},{\"quoteId\":6,\"speaker\":\"Unknown\",\"text\":\"A heart attack never stopped old Big Bear\",\"numberOfWords\":8},{\"quoteId\":7,\"speaker\":\"Buster\",\"text\":\"I didn't even know we were calling him Big Bear\",\"numberOfWords\":10},{\"quoteId\":8,\"speaker\":\"Unknown\",\"text\":\"You could charm the black off a telegram boy\",\"numberOfWords\":9},{\"quoteId\":9,\"speaker\":\"GOB\",\"text\":\"Did you see the new Poof?\",\"numberOfWords\":6},{\"quoteId\":10,\"speaker\":\"Lucille\",\"text\":\"I love all of my children equally\",\"numberOfWords\":7},{\"quoteId\":11,\"speaker\":\"Lucille\",\"text\":\"No one's called him Baby Buster since high school\",\"numberOfWords\":9}],\"totalCount\":480,\"page\":1,\"pageSize\":10}"

  // [    {        "quoteId": 1,        "text": "Some quote text",        "speaker": "Speaker Name",        "numberOfWords": 10    },    {        "quoteId": 2,        "text": "Another quote text",        "speaker": "Speaker Name",        "numberOfWords": 15    },    ...]

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
