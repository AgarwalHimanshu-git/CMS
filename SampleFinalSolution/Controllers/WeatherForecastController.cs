using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SampleFinalSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            string apiResponse = "[{\"date\": \"12/08/2023\", \"temperatureC\": \"34\", \"temperatureF\": \"90\", \"summary\": \"fsdgsdfgksdfg\"},{\"date\": \"12/08/2023\", \"temperatureC\": \"37\", \"temperatureF\": \"98\", \"summary\": \"fsdgsdfgksdfg\"}]";
            List<WeatherForecast>? forcasts = null;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(apiResponse)))
            {
                // Deserialization from JSON
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<WeatherForecast>));
                forcasts = (List<WeatherForecast>?)deserializer.ReadObject(ms);
            }
            return forcasts;
        }
    }
}