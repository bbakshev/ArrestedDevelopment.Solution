using System.Threading.Tasks;
using RestSharp;

namespace ArrestedDevelopmentClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCall()
    {
      RestClient client = new RestClient("http://localhost:5001/");
      RestRequest request = new RestRequest($"api/Quotes", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
  }
}