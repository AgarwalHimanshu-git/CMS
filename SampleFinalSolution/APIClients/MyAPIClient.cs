
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SampleFinalSolution.APIClients;

public static class MyApIClient
{
    // HttpClient is intended to be instantiated once per application, rather than per-use. 
    static readonly HttpClient client = new HttpClient();
    private const string CustomerUri = "https://getinvoices.azurewebsites.net/api/";

    public static async Task<string> GetData(string path)
    {
        try
        {
            string Url = CustomerUri + path;
            string responseBody = await client.GetStringAsync(Url);
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return e.ToString();
        }
    }
    public static async Task<HttpResponseMessage> PostData<T>(string path, T data)
    {
        HttpResponseMessage? response = null;
        try
        {
            string url = CustomerUri + path;
            response = await client.PostAsJsonAsync<T>(url, data);
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            throw new Exception(e.ToString());
        }
    }

    public static async Task<HttpResponseMessage> DeleteData(string path)
    {
        HttpResponseMessage? response = null;
        try
        {
            string url = CustomerUri + path;
            response = await client.DeleteAsync(url);
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            throw new Exception(e.ToString());
        }
    }

}

