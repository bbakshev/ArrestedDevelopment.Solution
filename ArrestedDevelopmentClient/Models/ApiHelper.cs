using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArrestedDevelopmentClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCall()
    {
      RestClient client = new RestClient("http://localhost:5001/");
      RestRequest request = new RestRequest($"api/Quotes/", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5001/");
      RestRequest request = new RestRequest($"api/Quotes/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newQuote)
    {
      RestClient client = new RestClient("http://localhost:5001/");
      RestRequest request = new RestRequest($"api/Quotes", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newQuote);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string quoteToEdit)
    {
      RestClient client = new RestClient("http://localhost:5001/");
      RestRequest request = new RestRequest($"api/Quotes/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(quoteToEdit);
      await client.PutAsync(request);
    }
  }
}