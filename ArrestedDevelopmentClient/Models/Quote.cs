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
      return quoteList.ToArray();
    }

    public static Quote GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Quote quote = JsonConvert.DeserializeObject<Quote>(jsonResponse.ToString());

      return quote;
    }

    public static void Post(Quote quote)
    {
      string jsonQuote = JsonConvert.SerializeObject(quote);
      ApiHelper.Post(jsonQuote);
    }

    public static void Put(Quote quoteToEdit)
    {
      string jsonQuote = JsonConvert.SerializeObject(quoteToEdit);
      ApiHelper.Put(quoteToEdit.QuoteId, jsonQuote);
    }
  }
}