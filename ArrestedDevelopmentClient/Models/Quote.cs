using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArrestedDevelopmentClient.Models
{
  public class Quote
  {
    public int QuoteId { get; set; }
    public string Text { get; set; }
    public string Speaker { get; set; }
    public int NumberOfWords { get; set; }

    public static Quote[] GetQuotes()
    {
      Task<string> apiCallTask = ApiHelper.ApiCall();
      string result =  apiCallTask.Result;

      JObject jsonResponse = JObject.Parse(result);
      List<Quote> quoteList = JsonConvert.DeserializeObject<List<Quote>>(jsonResponse["data"].ToString());

      // JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      // List<Quote> quoteList = JsonConvert.DeserializeObject<List<Quote>>(jsonResponse["results"].ToString());

      return quoteList.ToArray();
    }
  }
}