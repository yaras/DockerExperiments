using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ws1.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Hello from {Environment.MachineName}");

            string url = Environment.GetEnvironmentVariable("URL");

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();

            builder.AppendLine(responseString);

            return builder.ToString();
        }
    }
}
